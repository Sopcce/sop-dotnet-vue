﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;

namespace WebApi.StartupConfig
{
    /// <summary>
    /// </summary>
    public class TranslationTransformer : DynamicRouteValueTransformer
    {
        private readonly TranslationDatabase _translationDatabase;

        /// <summary>
        /// </summary>
        /// <param name="translationDatabase"></param>
        public TranslationTransformer(TranslationDatabase translationDatabase)
        {
            _translationDatabase = translationDatabase;
        }

        /// <summary>
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public override async ValueTask<RouteValueDictionary> TransformAsync(
            HttpContext httpContext, RouteValueDictionary values)
        {
            if (!values.ContainsKey("language") || !values.ContainsKey("controller") ||
                !values.ContainsKey("action")) return values;

            var language = (string) values["language"];
            var controller = await _translationDatabase.Resolve(language, (string) values["controller"]);
            if (controller == null) return values;
            values["controller"] = controller;

            var action = await _translationDatabase.Resolve(language, (string) values["action"]);
            if (action == null) return values;
            values["action"] = action;

            return values;
        }
    }
}