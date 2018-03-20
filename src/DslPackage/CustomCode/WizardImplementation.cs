﻿using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace Sawczyn.EFDesigner.EFModel
{
   public class WizardImplementation : IWizard
   {
      private static string modelPath;
      private static string diagramPath;
      private static DTE dte;

      public void RunStarted(object automationObject,
                             Dictionary<string, string> replacementsDictionary,
                             WizardRunKind runKind,
                             object[] customParams)
      {
      }

      public void ProjectFinishedGenerating(Project project)
      {
      }

      public void ProjectItemFinishedGenerating(ProjectItem projectItem)
      {
         dte = dte ?? projectItem.DTE;
         string path = projectItem.FileNames[0];

         if (path.EndsWith(".efmodel"))
            modelPath = path;
         else if (path.EndsWith(".diagram"))
            diagramPath = path;
      }

      public bool ShouldAddProjectItem(string filePath)
      {
         return true;
      }

      public void BeforeOpeningFile(ProjectItem projectItem)
      {
      }

      public void RunFinished()
      {
         // The VSIX can't nest files, so we'll do that here
         // NOTE: Don't nest the .tt file -- it doesn't seem to like that, and bad things happen
         if (modelPath != null && dte != null)
         {
            ProjectItem modelItem = dte.Solution.FindProjectItem(modelPath);
            if (modelItem != null && diagramPath != null)
            {
               ProjectItem diagramItem = dte.Solution.FindProjectItem(diagramPath);
               if (diagramItem != null)
               {
                  diagramItem.Remove();
                  modelItem.ProjectItems.AddFromFile(diagramPath);
               }
            }
         }

         diagramPath = null;
         modelPath = null;
         dte = null;
      }
   }
}