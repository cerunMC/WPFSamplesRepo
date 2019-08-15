            <!--  Resource https://blogs.msdn.microsoft.com/mikehillberg/2009/10/30/treeview-and-hierarchicaldatatemplate-step-by-step/  -->
            <!--  Binding to ExplorerViewModel ObservableCollection ExplorerObjs  -->
            <TreeView
                Name="ExplorerObjTree"
                Background="{DynamicResource ExplorerColor}"
                BorderThickness="0"
                ItemsSource="{Binding ExplorerObjs}">

                <!--  On SelectedItemChanged, return selected Content  -->
                <wi:Interaction.Triggers>
                    <wi:EventTrigger EventName="SelectedItemChanged">
                        <wi:InvokeCommandAction Command="{Binding SelectItemCommand}" CommandParameter="{Binding SelectedItem, ElementName=ExplorerObjTree, Mode=OneWay}" />
                    </wi:EventTrigger>
                </wi:Interaction.Triggers>

                <TreeView.ItemTemplate>

                    <!--  Binding to ExplorerObjViewModel Content  -->
                    <HierarchicalDataTemplate ItemsSource="{Binding Content}">
                        <TextBlock
                            VerticalAlignment="Center"
                            FontWeight="DemiBold"
                            Text="{Binding Path=Title, Mode=OneTime}" />

                        <!--  Content Template  -->
                        <HierarchicalDataTemplate.ItemTemplate>
                            <DataTemplate>
                                <TextBlock VerticalAlignment="Center" Text="{Binding Type, Mode=OneTime}" />
                            </DataTemplate>
                        </HierarchicalDataTemplate.ItemTemplate>
                    </HierarchicalDataTemplate>
                </TreeView.ItemTemplate>
            </TreeView>



 public RelayCommand<object> SelectItemCommand { get; private set; }
 
 
  private void OnSelectedItem(object Content)
  {
      if (Content is DataContext.Content c && c.Parent is ExplorerObjViewModel eovm)
      {
          eovm.PublishContentView(c);
      }
  }
