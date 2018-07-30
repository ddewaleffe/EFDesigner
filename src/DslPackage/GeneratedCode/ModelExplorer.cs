﻿//------------------------------------------------------------------------------
// <auto-generated>
//	 This code was generated by a tool.
//
//	 Changes to this file may cause incorrect behavior and will be lost if
//	 the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslShell = global::Microsoft.VisualStudio.Modeling.Shell;
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;

namespace Sawczyn.EFDesigner.EFModel
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	internal partial class EFModelExplorer : EFModelExplorerBase
	{
		/// <summary>
		/// Constructs a new EFModelExplorer.
		/// </summary>
		public EFModelExplorer(global::System.IServiceProvider serviceProvider)
			: base(serviceProvider)
		{
		}
	}
	
	/// <summary>
	/// Control hosted in the EFModelExplorerToolWindow.
	/// </summary>
	internal abstract class EFModelExplorerBase : DslShell::ModelExplorerTreeContainer
	{
		/// <summary>
		/// Constructs a new EFModelExplorerBase.
		/// </summary>
		protected EFModelExplorerBase(global::System.IServiceProvider serviceProvider) : base(serviceProvider)
		{
			try
			{	
				// Adds hidden path to hide elements from the explorer
				this.AddHiddenPath( new global::System.Guid[] { global::Sawczyn.EFDesigner.EFModel.Comment.DomainClassId }); 
			
			}
			catch (global::System.InvalidOperationException)
			{
				// Each hidden path specified needs to have odd number of guid entries.  The entries will alternative between
				// DomainRelationshipID and DomainClassID. The guids list should also start out with a DomainRelationshipID.
				// This exception will be swallowed...
				global::System.Diagnostics.Debug.Fail("Each hidden path specified needs to have odd number of guid entries.\r\nPlease update the HiddenNodes section under ExplorerBehavior in the DSL file\r\nso the Model Explorer can hide element properly.");
			}
			
			// Adds custom tree node settings...
			global::System.Resources.ResourceManager resourceManager = global::Sawczyn.EFDesigner.EFModel.EFModelDomainModel.SingletonResourceManager;
			
			this.AddExplorerNodeCustomSetting(global::Sawczyn.EFDesigner.EFModel.ModelClass.DomainClassId, 
							DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("ModelClassExplorerImage")), 
							false); 
			this.AddExplorerNodeCustomSetting(global::Sawczyn.EFDesigner.EFModel.ModelEnum.DomainClassId, 
							DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("ModelEnumExplorerImage")), 
							false); 
			this.AddExplorerNodeCustomSetting(global::Sawczyn.EFDesigner.EFModel.ModelView.DomainClassId, 
							DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("ModelViewExplorerImage")), 
							false); 
		}
	
	
	
		/// <summary>
		/// Create IElementVisitor
		/// </summary>
		/// <returns>IElementVisitor</returns>
		protected override DslModeling::IElementVisitor CreateElementVisitor()
		{
			return new DslShell::ExplorerElementVisitor(this);
		}
	
		/// <summary>
		/// Specifies the context menu that should be shown for the model explorer.
		///</summary>
		protected override global::System.ComponentModel.Design.CommandID ContextMenuCommandId
		{
			get
			{
				return Constants.EFModelExplorerMenu;
			}
		}
		
		/// <summary>
		/// Returns the root elements domain class Id. The is the very top level tree node in the TreeView
		///</summary>
		protected override global::System.Guid RootElementDomainClassId
		{
			get { return global::Sawczyn.EFDesigner.EFModel.ModelRoot.DomainClassId; }
		}
		
		/// <summary>
		/// Returns the root elements to be displayed in the explorer.
		///</summary>
		protected override global::System.Collections.IList FindRootElements(DslModeling::Store store)
		{
			return store.ElementDirectory.FindElements( this.RootElementDomainClassId);
		}
	}
}
	


