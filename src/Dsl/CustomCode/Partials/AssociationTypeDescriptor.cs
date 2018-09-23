﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Design;

namespace Sawczyn.EFDesigner.EFModel
{
   public partial class AssociationTypeDescriptor
   {
      private DomainDataDirectory storeDomainDataDirectory;

      /// <summary>
      ///    Returns the property descriptors for the described ModelClass domain class, adding tracking property
      ///    descriptor(s).
      /// </summary>
      private PropertyDescriptorCollection GetCustomProperties(Attribute[] attributes)
      {
         Association association = ModelElement as Association;

         // Get the default property descriptors from the base class  
         PropertyDescriptorCollection propertyDescriptors = base.GetProperties(attributes);

         //Add the descriptor for the tracking property.  
         if (association != null)
         {
            storeDomainDataDirectory = association.Store.DomainDataDirectory;

            // don't show delete actions unless that end is the principal role
            if (association.SourceRole != EndpointRole.Principal)
            {
               PropertyDescriptor sourceDeleteActionTypeDescriptor = propertyDescriptors.OfType<PropertyDescriptor>().Single(x => x.Name == "SourceDeleteAction");
               propertyDescriptors.Remove(sourceDeleteActionTypeDescriptor);
            }
            if (association.TargetRole != EndpointRole.Principal)
            {
               PropertyDescriptor targetDeleteActionTypeDescriptor = propertyDescriptors.OfType<PropertyDescriptor>().Single(x => x.Name == "TargetDeleteAction");
               propertyDescriptors.Remove(targetDeleteActionTypeDescriptor);
            }

            /********************************************************************************/

            DomainPropertyInfo collectionClassPropertyInfo = storeDomainDataDirectory.GetDomainProperty(Association.CollectionClassDomainPropertyId);
            DomainPropertyInfo isCollectionClassTrackingPropertyInfo = storeDomainDataDirectory.GetDomainProperty(Association.IsCollectionClassTrackingDomainPropertyId);

            // Define attributes for the tracking property/properties so that the Properties window displays them correctly.  
            Attribute[] collectionClassAttributes =
            {
               new DisplayNameAttribute("Collection Class"),
               new DescriptionAttribute("Type of collections generated. Overrides the default collection class for the model"),
               new CategoryAttribute("Code Generation")
            };

            propertyDescriptors.Add(new TrackingPropertyDescriptor(association, collectionClassPropertyInfo, isCollectionClassTrackingPropertyInfo, collectionClassAttributes));
         }

         // Return the property descriptors for this element  
         return propertyDescriptors;
      }

   }
}
