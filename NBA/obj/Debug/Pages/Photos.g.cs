﻿#pragma checksum "..\..\..\Pages\Photos.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4C56308BA44F880B4B9E9801229D8DEEC36AFE1597414B2C13A5DA4523DA42E0"
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
    /// Photos
    /// </summary>
    public partial class Photos : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\Pages\Photos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BPrevious;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Pages\Photos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TBPage;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Pages\Photos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BNext;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Pages\Photos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BLoadPhoto;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Pages\Photos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LVPhotos;
        
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
            System.Uri resourceLocater = new System.Uri("/NBA-2hour;component/pages/photos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Photos.xaml"
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
            
            #line 10 "..\..\..\Pages\Photos.xaml"
            ((NBA_2hour.Pages.Photos)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BPrevious = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Pages\Photos.xaml"
            this.BPrevious.Click += new System.Windows.RoutedEventHandler(this.BPrevious_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TBPage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.BNext = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Pages\Photos.xaml"
            this.BNext.Click += new System.Windows.RoutedEventHandler(this.BNext_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BLoadPhoto = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\Pages\Photos.xaml"
            this.BLoadPhoto.Click += new System.Windows.RoutedEventHandler(this.BLoadPhoto_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LVPhotos = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

