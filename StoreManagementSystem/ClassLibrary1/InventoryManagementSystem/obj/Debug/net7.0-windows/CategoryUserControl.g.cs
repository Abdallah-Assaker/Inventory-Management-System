﻿#pragma checksum "..\..\..\CategoryUserControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B6725D2FF9FAD42BFCD527F8AC063EF31E044619"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using InventoryManagementSystem;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace InventoryManagementSystem {
    
    
    /// <summary>
    /// CategoryUserControl
    /// </summary>
    public partial class CategoryUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\CategoryUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CategoryPage_InventoryComboBx;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\CategoryUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CategoryNameInCategoryPageTxtBx;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\CategoryUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddNewCategory;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\CategoryUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditCategory;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\CategoryUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteCategory;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\CategoryUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView CategoryListView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/InventoryManagementSystem;component/categoryusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CategoryUserControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CategoryPage_InventoryComboBx = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\..\CategoryUserControl.xaml"
            this.CategoryPage_InventoryComboBx.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CategoryPage_InventoryComboBx_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CategoryNameInCategoryPageTxtBx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.AddNewCategory = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\CategoryUserControl.xaml"
            this.AddNewCategory.Click += new System.Windows.RoutedEventHandler(this.AddNewCategory_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.EditCategory = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\CategoryUserControl.xaml"
            this.EditCategory.Click += new System.Windows.RoutedEventHandler(this.EditCategory_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DeleteCategory = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\CategoryUserControl.xaml"
            this.DeleteCategory.Click += new System.Windows.RoutedEventHandler(this.DeleteCategory_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CategoryListView = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

