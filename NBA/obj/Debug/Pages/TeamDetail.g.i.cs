﻿#pragma checksum "..\..\..\Pages\TeamDetail.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FFF021FA9CE67E815B90EF2ED925C0C3E427D9070791C3D6811C810A914623E4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using NBA_2hour.Pages;
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


namespace NBA_2hour.Pages {
    
    
    /// <summary>
    /// TeamDetail
    /// </summary>
    public partial class TeamDetail : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\Pages\TeamDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBSeason;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Pages\TeamDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BSearch;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Pages\TeamDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGPlayers;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\Pages\TeamDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGMatchup;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\Pages\TeamDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LVPLayersPF;
        
        #line default
        #line hidden
        
        
        #line 192 "..\..\..\Pages\TeamDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LVPLayersSG;
        
        #line default
        #line hidden
        
        
        #line 234 "..\..\..\Pages\TeamDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LVPLayersC;
        
        #line default
        #line hidden
        
        
        #line 273 "..\..\..\Pages\TeamDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LVPLayersSF;
        
        #line default
        #line hidden
        
        
        #line 313 "..\..\..\Pages\TeamDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LVPLayersPG;
        
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
            System.Uri resourceLocater = new System.Uri("/NBA-2hour;component/pages/teamdetail.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\TeamDetail.xaml"
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
            
            #line 11 "..\..\..\Pages\TeamDetail.xaml"
            ((NBA_2hour.Pages.TeamDetail)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CBSeason = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.BSearch = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\Pages\TeamDetail.xaml"
            this.BSearch.Click += new System.Windows.RoutedEventHandler(this.BSearch_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DGPlayers = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.DGMatchup = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.LVPLayersPF = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.LVPLayersSG = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.LVPLayersC = ((System.Windows.Controls.ListView)(target));
            return;
            case 9:
            this.LVPLayersSF = ((System.Windows.Controls.ListView)(target));
            return;
            case 10:
            this.LVPLayersPG = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

