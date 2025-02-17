# How to dynamically adjust the height of the SfDataGrid based on SfBottomSheet Size Changes ?
In this article, we will show you how to dynamically adjust the height of the [.NET MAUI DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid) based on SfBottomSheet Size Changes.

## Xaml
```
 <ContentPage.BindingContext>
     <local:EmployeeViewModel x:Name="viewModel" />
 </ContentPage.BindingContext>

 <Grid>
     <Grid>
         <Button Text="ShowBottomSheet" HorizontalOptions="Center" VerticalOptions="Center"
                 Clicked="Button_Clicked" />
     </Grid>
  <!-- Bottom Sheet Section -->
     <bottomSheet:SfBottomSheet x:Name="bottomSheet"
                                HalfExpandedRatio="0.55"
                                CollapsedHeight="100"
                                AllowedState="All"
                                CornerRadius="15, 15, 0, 0">
         <bottomSheet:SfBottomSheet.BottomSheetContent>
             <!--Add your content here-->
         <Grid RowDefinitions="*,48" x:Name="gridLayout"
               ColumnDefinitions="*"
               Margin="10,-5,10,10" >

                 <StackLayout x:Name="hslDataGrid" VerticalOptions="FillAndExpand" HorizontalOptions="FillAndExpand"
                                        Grid.Row="0">
                     <datagrid:SfDataGrid AutoGenerateColumnsMode="None"
                                          GridLinesVisibility="Both"
                                          HeaderGridLinesVisibility="Both"
                                          x:Name="dataGrid"
                                          Margin="0,0,0,0"
                                          ItemsSource="{Binding Employees}"
                                          MinimumHeightRequest="0"
                                          SelectionMode="Single"
                                          NavigationMode="Cell"
                                          ColumnWidthMode="Auto"
                                          HeaderRowHeight="42"
                                          VerticalOptions="FillAndExpand"
                                          HorizontalOptions="FillAndExpand"
                                          RowHeight="42">
                         <datagrid:SfDataGrid.Columns>
                             <datagrid:DataGridTextColumn HeaderText="Employee Name"
                                                          MappingName="Name" />
                             <datagrid:DataGridNumericColumn  HeaderText="Employee ID"
                                                              Format="#"
                                                              MappingName="EmployeeID" />
                             <datagrid:DataGridTextColumn  HeaderText="Designation"
                                                           MappingName="Title" />
                             <datagrid:DataGridTextColumn  HeaderText="Gender"
                                                           MappingName="Gender" />
                             <datagrid:DataGridTextColumn  HeaderText="Marital Status"
                                                           MappingName="MaritalStatus" />

                         </datagrid:SfDataGrid.Columns>
                     </datagrid:SfDataGrid>
             </StackLayout>
                 <StackLayout Grid.Row="1">
                     <buttons:SfButton x:Name="btnSelCon"
                                   Text="Click Me"
                                   Clicked="BtnSelCon_OnClicked"
                                   HorizontalTextAlignment="Center"
                                   Margin="0,15,0,0"
                                   Padding="1"
                                   HeightRequest="30"
                                   WidthRequest="85" />
             </StackLayout>
         </Grid>
     </bottomSheet:SfBottomSheet.BottomSheetContent>
 </bottomSheet:SfBottomSheet>
 <!-- Bottom Sheet Section -->
 </Grid>
```

## Xaml.cs
The code below demonstrates how to dynamically adjust the height of the `SfDataGrid` based on `SfBottomSheet` size changes.
```
private void Button_Clicked(object sender, EventArgs e)
{
    double screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;

    double ratio = CalculateExpandRatio(bottomSheet.BottomSheetContent, screenHeight);

    bottomSheet.HalfExpandedRatio = ratio;

    bottomSheet.Show();
}

public double CalculateExpandRatio(View bottomSheetContent, double screenHeight)
{

    double contentHeight = 0;

    contentHeight = bottomSheetContent.Measure(double.PositiveInfinity, double.PositiveInfinity).Height;

    // Define minimum and maximum ratios

    double minRatio = 0.4;

    double maxRatio = 0.9;


    // Calculate the ratio based on content height relative to screen height

    double calculatedRatio = contentHeight / screenHeight;


    // Ensure ratio stays within platform-specific bounds

    double finalRatio = Math.Clamp(calculatedRatio, minRatio, maxRatio);

    return finalRatio;

}
```

<img src="https://support.syncfusion.com/kb/agent/attachment/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjM1OTA1Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.tDdkNyWb5kOmFdJ3Ek2jdo12AJV6OkAc-vPgYBDFaec" width=800/>

[View sample in GitHub](https://github.com/SyncfusionExamples/How-to-dynamically-adjust-the-height-of-the-SfDataGrid-based-on-SfBottomSheet-Size-Changes)

Take a moment to explore this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more information about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples. Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid (SfDataGrid).
 
##### Conclusion
 
I hope you enjoyed learning about how to dynamically adjust the height of the `SfDataGrid` based on `SfBottomSheet` size changes.
 
You can refer to our [.NET MAUI DataGrid’s feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI DataGrid Documentation](https://help.syncfusion.com/maui/datagrid/getting-started) to understand how to present and manipulate data. 
For current customers, you can check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI DataGrid and other .NET MAUI components.
 
If you have any queries or require clarifications, please let us know in the comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid), or the feedback portal. We are always happy to assist you!