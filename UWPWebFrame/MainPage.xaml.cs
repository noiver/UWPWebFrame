﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace UWPWebFrame
{

    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // 为不同的菜单创建不同的List类型
        private List<NavMenuItem> navMenuPrimaryItem = new List<NavMenuItem>(
            new[]
            {
                new NavMenuItem()
                {
                    FontFamily = new FontFamily("Segoe MDL2 Assets"),
                    Icon = "\xE10F",
                    Label = "主页",
                    Selected = Visibility.Visible,
                    DestPage = typeof(WebPage)
                },

                new NavMenuItem()
                {
                    FontFamily = new FontFamily("Segoe MDL2 Assets"),
                    Icon = "\xE11A",
                    Label = "页面2",
                    Selected = Visibility.Collapsed,
                    DestPage = typeof(SettingPage)
                },

                new NavMenuItem()
                {
                    FontFamily = new FontFamily("Segoe MDL2 Assets"),
                    Icon = "\xE121",
                    Label = "页面3",
                    Selected = Visibility.Collapsed,
                    DestPage = typeof(SettingPage)
                },

                new NavMenuItem()
                {
                    FontFamily = new FontFamily("Segoe MDL2 Assets"),
                    Icon = "\xE122",
                    Label = "页面4",
                    Selected = Visibility.Collapsed,
                    DestPage = typeof(WebPage)
                }

            });

        private List<NavMenuItem> navMenuSecondaryItem = new List<NavMenuItem>(
            new[]
            {
                new NavMenuItem()
                {
                    FontFamily = new FontFamily("Segoe MDL2 Assets"),
                    Icon = "\xE713",
                    Label = "设置",
                    Selected = Visibility.Collapsed,
                    DestPage = typeof(SettingPage)
                },
            new NavMenuItem()
                {
                    FontFamily = new FontFamily("Segoe MDL2 Assets"),
                    Icon = "\xE7E8",
                    Label = "退出",
                    Selected = Visibility.Collapsed,
                    DestPage = typeof(SettingPage)
                }
            });
        public MainPage()
        {
            this.InitializeComponent();
            // 绑定导航菜单
            NavMenuPrimaryListView.ItemsSource = navMenuPrimaryItem;
            NavMenuSecondaryListView.ItemsSource = navMenuSecondaryItem;
            // SplitView 开关
            PaneOpenButton.Click += (sender, args) =>
            {
                RootSplitView.IsPaneOpen = !RootSplitView.IsPaneOpen;
            };
            // 导航事件
            NavMenuPrimaryListView.ItemClick += NavMenuListView_ItemClick;
            NavMenuSecondaryListView.ItemClick += NavMenuListView_ItemClick;
            // 默认页
            RootFrame.SourcePageType = typeof(WebPage);
        }

        private void NavMenuListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 遍历，将选中Rectangle隐藏
            foreach (var np in navMenuPrimaryItem)
            {
                np.Selected = Visibility.Collapsed;
            }
            foreach (var ns in navMenuSecondaryItem)
            {
                ns.Selected = Visibility.Collapsed;
            }

            NavMenuItem item = e.ClickedItem as NavMenuItem;
            // Rectangle显示并导航
            item.Selected = Visibility.Visible;
            if (item.DestPage != null)
            {
                RootFrame.Navigate(item.DestPage);
            }

            RootSplitView.IsPaneOpen = false;
        }
    }
}

