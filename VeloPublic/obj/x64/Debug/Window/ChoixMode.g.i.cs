﻿#pragma checksum "..\..\..\..\Window\ChoixMode.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9DD66C29ADF08ED85535A3A6B76D92BA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Dragablz;
using Dragablz.Dockablz;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using VeloPublic;


namespace VeloPublic {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\Window\ChoixMode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelTitre;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Window\ChoixMode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image modeCollaboImage;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Window\ChoixMode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelDefi;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Window\ChoixMode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image modeDefiImage;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Window\ChoixMode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelCollabo;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Window\ChoixMode.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ParamEvenementImage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/VeloPublic;component/window/choixmode.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Window\ChoixMode.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.labelTitre = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.modeCollaboImage = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.labelDefi = ((System.Windows.Controls.Label)(target));
            
            #line 17 "..\..\..\..\Window\ChoixMode.xaml"
            this.labelDefi.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.labelDefi_MouseUp);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\..\Window\ChoixMode.xaml"
            this.labelDefi.MouseEnter += new System.Windows.Input.MouseEventHandler(this.labelDefi_MouseEnter);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\..\Window\ChoixMode.xaml"
            this.labelDefi.MouseLeave += new System.Windows.Input.MouseEventHandler(this.labelDefi_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.modeDefiImage = ((System.Windows.Controls.Image)(target));
            
            #line 18 "..\..\..\..\Window\ChoixMode.xaml"
            this.modeDefiImage.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.modeDefiImage_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.labelCollabo = ((System.Windows.Controls.Label)(target));
            
            #line 19 "..\..\..\..\Window\ChoixMode.xaml"
            this.labelCollabo.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.labelCollabo_MouseUp);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\..\Window\ChoixMode.xaml"
            this.labelCollabo.MouseEnter += new System.Windows.Input.MouseEventHandler(this.labelCollabo_MouseEnter);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\..\Window\ChoixMode.xaml"
            this.labelCollabo.MouseLeave += new System.Windows.Input.MouseEventHandler(this.labelCollabo_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ParamEvenementImage = ((System.Windows.Controls.Image)(target));
            
            #line 20 "..\..\..\..\Window\ChoixMode.xaml"
            this.ParamEvenementImage.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ParamEvenementImage_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

