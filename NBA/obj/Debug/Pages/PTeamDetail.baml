   M S B A M L   `   `   `  ????>  :NBA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NBA.Pages	NBA.Pages  5          NBA.Pages.PTeamDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:NBA.Pages     5        N? Title$  PTeamDetail??5	      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      .+?5   
   ??  ?? Orientation$ 
Horizontal=?6   .+?5      ?? $	??120??5      ??5      ?? *Logo+5      ?? 5      $??Center=?6   $ 
Horizontal=?5      .+?5      ?? $??Verdana)?5       ???#474747$??20(?5       ??5      ?? *
TeamName+5       ?? 5      $	?? | ??6   $??Verdana)?5       ???#474747$??20(?5       ?? 5      $??Verdana)?5       ???#474747$??20(?5        ??5      ?? *Division.Name+5        ?? 5!      $	?? | ??6   $??Verdana)?5"       ???#474747$??20(?5$       ?? 5%      $??Verdana)?5&       ???#474747$??20(?5(       ??5%      ?? *Division.Conference.Name+5(       5)      5*      ?? 5+   
   -   5         ??Name$ TCTeam??5,      $??1??5+      .@?5-      ?? -   5         ??Name$ TIRoster??5-      ??5.      ?? 5/      $??Roster??6    $??Verdana)?50       ???#595959$??20(?52       $??Center=?53       ??55      &   System.Windows.Controls.DataGrid  56      -   5          Name$ DGPlayerInTeam??58         
IsReadOnly .    AutoGenerateColumns .     Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn	   Header$		 No.??61   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5;   1   ?? *ShirtNumber+  5<      $
	 Name??61   
 5=   1   ?? *Player.Name+  5>      $	 Position??61   
 6C   ?? *Player.Position.Abbr+  5?      $	 DateofBirth??61   
 6F   ?? *Player.DateOfBirth+  5@      $	 College??61   
 6B   ?? *Player.College+  5A      $	 
Experience??61   -   5        TCExperience??
 5C   1   ?? *Player.Experience+  5D      $	 Salary??61   
 5E   1   ?? *Salary+5G      5I      ?? 5J      -   5        $ 	TIMatchup??5J      ??5K      ?? 5L      $??Matchup??6    $??Verdana)?5M       ???#595959$??20(?5O       $??Center=?5P       ??5R        5S      -   5        $ 	DGMatchup??5S       .  .   5V        5W      $
	 Date??61   
 5X   1   ?? *	Starttime+ ?? StringFormat$ {0:dd/MM/yyyy}??  5Y      $	 Matchup Type??61   
 5Z   1   ?? *MatchupType.Name+  5[      $	 Opponent??61   
 5\   1   ?? *Team1.TeamName+  5]      $	 
Start time??61   
 5^   1   ?? *	Starttime+$ {0:hh:mm tt}??  5_      $	 Result??61   
 5`   "   `? 5a   &   $ 	{0} - {1}??64   .1?5b   *   ??  ?? Path$ Team_Away_Score?62   ?? 5c   *   $ Team_Home_Score?62   5d   '   5f        5g      $	 Location??61   
 5h   1   ?? *
Location+  5i      $	 Status??61   
 5j   1   ?? *Status+5l      5n      ?? 5o      -   5        $ TILineup??5o      ??5p      ?? 5q      $??Lineup??6    $??Verdana)?5r       ???#595959$??20(?5t       $??Center=?5u       ??5w      ? 5x      ??5y      ?? 5z       ?? ImageSource$ /images/gym.jpg??6)   .+?5|      ?  ? ColumnDefinitions 5}      ?? 5~   "   ?? 5   "   ?? 5?   "    5?      ?? 5?   "   ?? 5?   "   $	??100 ?60   .+?5?      ?? -   5         ??Name$ 	LVPLayers??5?   (   $	??150??5?   '   $	??100??5?   (   $??Bottom=?5?   (   $??0,0,0,20q?5?   (   ??5?   "   ?? 5?   &   .R?5?   *   ?? .+?5?   .   ?? ??68   ?? *Player.Name+5?   +   5?   '   5?      5?      5?      5?      5?      5?      5?      