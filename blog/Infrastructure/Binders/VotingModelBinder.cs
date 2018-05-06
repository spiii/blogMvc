using blogBl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mmodelBinding = System.Web.ModelBinding;

namespace blog.Infrastructure.Binders
{
    public class VotingModelBinder : IModelBinder
    {
        private const string sessionKey = "voting";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Voting voting = null;
            
            // Create voting from session.
            if (controllerContext.HttpContext.Session != null)
            {
                voting = (Voting)controllerContext.HttpContext.Session[sessionKey];
            }

            // If voting is empty, create one and save it into session.
            if (voting == null)
            {
                voting = new Voting();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = voting;
                }
            }

            return voting;
        }


    }
}