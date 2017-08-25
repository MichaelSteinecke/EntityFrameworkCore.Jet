EntityFramework.Jet.FunctionalTests.FiltersJetTest.Compiled_query() : 
            AssertSql(
                @"@__customerID='BERGS' (Size = 255)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = @__customerID",
                //
                @"@__customerID='BLAUS' (Size = 255)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = @__customerID");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Select_correlated_filtered_collection_works_with_caching() : 
            AssertSql(
                @"SELECT [t].[GearNickName]
FROM [CogTag] AS [t]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_alias_generation(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
ORDER BY [o].[OrderID]",
                //
                @"SELECT [o#OrderDetails].[OrderID], [o#OrderDetails].[ProductID], [o#OrderDetails].[Discount], [o#OrderDetails].[Quantity], [o#OrderDetails].[UnitPrice]
FROM [Order Details] AS [o#OrderDetails]
INNER JOIN (
    SELECT [o0].[OrderID]
    FROM [Orders] AS [o0]
) AS [t] ON [o#OrderDetails].[OrderID] = [t].[OrderID]
ORDER BY [t].[OrderID]");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Include_on_GroupJoin_SelectMany_DefaultIfEmpty_with_inheritance_and_coalesce_result() : 
            AssertSql(
                @"SELECT [g].[Nickname], [g].[SquadId], [g].[AssignedCityName], [g].[CityOrBirthName], [g].[Discriminator], [g].[FullName], [g].[HasSoulPatch], [g].[LeaderNickname], [g].[LeaderSquadId], [g].[Rank], [t].[Nickname], [t].[SquadId], [t].[AssignedCityName], [t].[CityOrBirthName], [t].[Discriminator], [t].[FullName], [t].[HasSoulPatch], [t].[LeaderNickname], [t].[LeaderSquadId], [t].[Rank]
FROM [Gear] AS [g]
LEFT JOIN (
    SELECT [g2].*
    FROM [Gear] AS [g2]
    WHERE [g2].[Discriminator] = 'Officer'
) AS [t] ON [g].[LeaderNickname] = [t].[Nickname]
WHERE [g].[Discriminator] IN ('Officer', 'Gear')
ORDER BY [t].[FullName], [g].[FullName]");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Select_ternary_operation_with_has_value_not_null() : 
            AssertSql(
                @"SELECT [w].[Id], IIf(
    [w].[AmmunitionType] IS NOT NULL AND ([w].[AmmunitionType] = 1),
    'Yes',
    'No'
) AS [IsCartidge]
FROM [Weapon] AS [w]
WHERE [w].[AmmunitionType] IS NOT NULL AND ([w].[AmmunitionType] = 1)");



EntityFramework.Jet.FunctionalTests.FiltersJetTest.Include_query_opt_out() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Select_inverted_boolean() : 
            AssertSql(
                @"SELECT [w].[Id], IIf(
    [w].[IsAutomatic] = False,
    True,
    False
) AS [Manual]
FROM [Weapon] AS [w]
WHERE [w].[IsAutomatic] = True");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Include_on_GroupJoin_SelectMany_DefaultIfEmpty_with_complex_projection_result() : 
            AssertSql(
                @"SELECT [g].[Nickname], [g].[SquadId], [g].[AssignedCityName], [g].[CityOrBirthName], [g].[Discriminator], [g].[FullName], [g].[HasSoulPatch], [g].[LeaderNickname], [g].[LeaderSquadId], [g].[Rank], [t].[Nickname], [t].[SquadId], [t].[AssignedCityName], [t].[CityOrBirthName], [t].[Discriminator], [t].[FullName], [t].[HasSoulPatch], [t].[LeaderNickname], [t].[LeaderSquadId], [t].[Rank]
FROM [Gear] AS [g]
LEFT JOIN (
    SELECT [g2].*
    FROM [Gear] AS [g2]
    WHERE [g2].[Discriminator] IN ('Officer', 'Gear')
) AS [t] ON [g].[LeaderNickname] = [t].[Nickname]
WHERE [g].[Discriminator] IN ('Officer', 'Gear')
ORDER BY [g].[FullName], [t].[FullName]");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Sum_with_optional_navigation_is_translated_to_sql() : 
            AssertSql(
                @"SELECT SUM([g].[SquadId])
FROM [Gear] AS [g]
LEFT JOIN [CogTag] AS [g#Tag] ON ([g].[Nickname] = [g#Tag].[GearNickName]) AND ([g].[SquadId] = [g#Tag].[GearSquadId])
WHERE [g].[Discriminator] IN ('Officer', 'Gear') AND (([g#Tag].[Note] <> 'Foo') OR [g#Tag].[Note] IS NULL)");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_kiwi() : 
            AssertSql(
                @"SELECT [k].[Species], [k].[CountryId], [k].[Discriminator], [k].[Name], [k].[EagleId], [k].[IsFlightless], [k].[FoundOn]
FROM [Animal] AS [k]
WHERE ([k].[Discriminator] = 'Kiwi') AND ([k].[CountryId] = 1)");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_bird_first() : 
            AssertSql(
                @"SELECT TOP 1 [b].[Species], [b].[CountryId], [b].[Discriminator], [b].[Name], [b].[EagleId], [b].[IsFlightless], [b].[Group], [b].[FoundOn]
FROM [Animal] AS [b]
WHERE [b].[Discriminator] IN ('Kiwi', 'Eagle') AND ([b].[CountryId] = 1)
ORDER BY [b].[Species]");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_is_kiwi_in_projection() : 
            AssertSql(
                @"SELECT IIf(
    [a].[Discriminator] = 'Kiwi',
    True,
    False
)
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle') AND ([a].[CountryId] = 1)");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_alias_generation(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
ORDER BY [o].[OrderID]",
                //
                @"SELECT [o#OrderDetails].[OrderID], [o#OrderDetails].[ProductID], [o#OrderDetails].[Discount], [o#OrderDetails].[Quantity], [o#OrderDetails].[UnitPrice]
FROM [Order Details] AS [o#OrderDetails]
INNER JOIN (
    SELECT [o0].[OrderID]
    FROM [Orders] AS [o0]
) AS [t] ON [o#OrderDetails].[OrderID] = [t].[OrderID]
ORDER BY [t].[OrderID]");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_bird_with_projection() : 
            AssertSql(
                @"SELECT [b].[EagleId]
FROM [Animal] AS [b]
WHERE [b].[Discriminator] IN ('Kiwi', 'Eagle') AND ([b].[CountryId] = 1)");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_is_kiwi() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE ([a].[Discriminator] IN ('Kiwi', 'Eagle') AND ([a].[CountryId] = 1)) AND ([a].[Discriminator] = 'Kiwi')");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_bird_predicate() : 
            AssertSql(
                @"SELECT [b].[Species], [b].[CountryId], [b].[Discriminator], [b].[Name], [b].[EagleId], [b].[IsFlightless], [b].[Group], [b].[FoundOn]
FROM [Animal] AS [b]
WHERE ([b].[Discriminator] IN ('Kiwi', 'Eagle') AND ([b].[CountryId] = 1)) AND ([b].[CountryId] = 1)
ORDER BY [b].[Species]");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_animal() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle') AND ([a].[CountryId] = 1)
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_bird() : 
            AssertSql(
                @"SELECT [b].[Species], [b].[CountryId], [b].[Discriminator], [b].[Name], [b].[EagleId], [b].[IsFlightless], [b].[Group], [b].[FoundOn]
FROM [Animal] AS [b]
WHERE [b].[Discriminator] IN ('Kiwi', 'Eagle') AND ([b].[CountryId] = 1)
ORDER BY [b].[Species]");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_is_kiwi_with_other_predicate() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE ([a].[Discriminator] IN ('Kiwi', 'Eagle') AND ([a].[CountryId] = 1)) AND (([a].[Discriminator] = 'Kiwi') AND ([a].[CountryId] = 1))");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Select_comparison_with_null() : 
            AssertSql(
                @"@__ammunitionType_1='Cartridge' (Nullable = true)
@__ammunitionType_0='Cartridge' (Nullable = true)

SELECT [w].[Id], IIf(
    [w].[AmmunitionType] = @__ammunitionType_1,
    True,
    False
) AS [Cartidge]
FROM [Weapon] AS [w]
WHERE [w].[AmmunitionType] = @__ammunitionType_0",
                //
                @"SELECT [w].[Id], IIf(
    [w].[AmmunitionType] IS NULL,
    True,
    False
) AS [Cartidge]
FROM [Weapon] AS [w]
WHERE [w].[AmmunitionType] IS NULL");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Entity_equality_empty() : 
            AssertSql(
                @"SELECT [g].[Nickname], [g].[SquadId], [g].[AssignedCityName], [g].[CityOrBirthName], [g].[Discriminator], [g].[FullName], [g].[HasSoulPatch], [g].[LeaderNickname], [g].[LeaderSquadId], [g].[Rank]
FROM [Gear] AS [g]
WHERE [g].[Discriminator] IN ('Officer', 'Gear') AND ([g].[Nickname] IS NULL AND ([g].[SquadId] = 0))");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Discriminator_used_when_projection_over_of_type() : 
            AssertSql(
                @"SELECT [k].[FoundOn]
FROM [Animal] AS [k]
WHERE [k].[Discriminator] = 'Kiwi'");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_query_all_types_when_shared_column() : 
            AssertSql(
                @"SELECT [d].[Id], [d].[Discriminator], [d].[CaffeineGrams], [d].[CokeCO2], [d].[SugarGrams], [d].[LiltCO2], [d].[HasMilk]
FROM [Drink] AS [d]
WHERE [d].[Discriminator] IN ('Tea', 'Lilt', 'Coke', 'Drink')");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_kiwi_where_north_on_derived_property() : 
            AssertSql(
                @"SELECT [x].[Species], [x].[CountryId], [x].[Discriminator], [x].[Name], [x].[EagleId], [x].[IsFlightless], [x].[FoundOn]
FROM [Animal] AS [x]
WHERE ([x].[Discriminator] = 'Kiwi') AND ([x].[FoundOn] = 0)");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_alias_generation(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[ProductID], [o].[Discount], [o].[Quantity], [o].[UnitPrice], [o#Order].[OrderID], [o#Order].[CustomerID], [o#Order].[EmployeeID], [o#Order].[OrderDate]
FROM [Order Details] AS [o]
INNER JOIN [Orders] AS [o#Order] ON [o].[OrderID] = [o#Order].[OrderID]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_include_prey() : 
            AssertSql(
                @"SELECT TOP 2 [e].[Species], [e].[CountryId], [e].[Discriminator], [e].[Name], [e].[EagleId], [e].[IsFlightless], [e].[Group]
FROM [Animal] AS [e]
WHERE [e].[Discriminator] = 'Eagle'
ORDER BY [e].[Species]",
                //
                @"SELECT [e#Prey].[Species], [e#Prey].[CountryId], [e#Prey].[Discriminator], [e#Prey].[Name], [e#Prey].[EagleId], [e#Prey].[IsFlightless], [e#Prey].[Group], [e#Prey].[FoundOn]
FROM [Animal] AS [e#Prey]
INNER JOIN (
    SELECT TOP 1 [e0].[Species]
    FROM [Animal] AS [e0]
    WHERE [e0].[Discriminator] = 'Eagle'
    ORDER BY [e0].[Species]
) AS [t] ON [e#Prey].[EagleId] = [t].[Species]
WHERE [e#Prey].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [t].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Discriminator_used_when_projection_over_derived_type() : 
            AssertSql(
                @"SELECT [k].[FoundOn]
FROM [Animal] AS [k]
WHERE [k].[Discriminator] = 'Kiwi'");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_animal() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_bird() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_query_when_shared_column() : 
            AssertSql(
                @"SELECT TOP 2 [d].[Id], [d].[Discriminator], [d].[CaffeineGrams], [d].[CokeCO2], [d].[SugarGrams]
FROM [Drink] AS [d]
WHERE [d].[Discriminator] = 'Coke'",
                //
                @"SELECT TOP 2 [d].[Id], [d].[Discriminator], [d].[LiltCO2], [d].[SugarGrams]
FROM [Drink] AS [d]
WHERE [d].[Discriminator] = 'Lilt'",
                //
                @"SELECT TOP 2 [d].[Id], [d].[Discriminator], [d].[CaffeineGrams], [d].[HasMilk]
FROM [Drink] AS [d]
WHERE [d].[Discriminator] = 'Tea'");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_kiwi_where_south_on_derived_property() : 
            AssertSql(
                @"SELECT [x].[Species], [x].[CountryId], [x].[Discriminator], [x].[Name], [x].[EagleId], [x].[IsFlightless], [x].[FoundOn]
FROM [Animal] AS [x]
WHERE ([x].[Discriminator] = 'Kiwi') AND ([x].[FoundOn] = 1)");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_is_kiwi_with_other_predicate() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle') AND (([a].[Discriminator] = 'Kiwi') AND ([a].[CountryId] = 1))");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_bird_with_projection() : 
            AssertSql(
                @"SELECT [b].[EagleId]
FROM [Animal] AS [b]
WHERE [b].[Discriminator] IN ('Kiwi', 'Eagle')");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_query_just_roses() : 
            AssertSql(
                @"SELECT TOP 2 [p].[Species], [p].[CountryId], [p].[Genus], [p].[Name], [p].[HasThorns]
FROM [Plant] AS [p]
WHERE [p].[Genus] = 0");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_bird_predicate() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle') AND ([a].[CountryId] = 1)
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_is_kiwi_in_projection() : 
            AssertSql(
                @"SELECT IIf(
    [a].[Discriminator] = 'Kiwi',
    True,
    False
)
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle')");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_query_just_kiwis() : 
            AssertSql(
                @"SELECT TOP 2 [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] = 'Kiwi'");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_include_animals() : 
            AssertSql(
                @"SELECT [c].[Id], [c].[Name]
FROM [Country] AS [c]
ORDER BY [c].[Name], [c].[Id]",
                //
                @"SELECT [c#Animals].[Species], [c#Animals].[CountryId], [c#Animals].[Discriminator], [c#Animals].[Name], [c#Animals].[EagleId], [c#Animals].[IsFlightless], [c#Animals].[Group], [c#Animals].[FoundOn]
FROM [Animal] AS [c#Animals]
INNER JOIN (
    SELECT [c0].[Id], [c0].[Name]
    FROM [Country] AS [c0]
) AS [t] ON [c#Animals].[CountryId] = [t].[Id]
WHERE [c#Animals].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [t].[Name], [t].[Id]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_filter_all_animals() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle') AND ([a].[Name] = 'Great spotted kiwi')
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_kiwi() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] = 'Kiwi'");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_is_kiwi() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle') AND ([a].[Discriminator] = 'Kiwi')");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_bird_first() : 
            AssertSql(
                @"SELECT TOP 1 [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Discriminator_used_when_projection_over_derived_type2() : 
            AssertSql(
                @"SELECT [b].[IsFlightless], [b].[Discriminator]
FROM [Animal] AS [b]
WHERE [b].[Discriminator] IN ('Kiwi', 'Eagle')");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_query_all_animals() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_alias_generation(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[ProductID], [o].[Discount], [o].[Quantity], [o].[UnitPrice], [o#Order].[OrderID], [o#Order].[CustomerID], [o#Order].[EmployeeID], [o#Order].[OrderDate]
FROM [Order Details] AS [o]
INNER JOIN [Orders] AS [o#Order] ON [o].[OrderID] = [o#Order].[OrderID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_on_join_clause_with_order_by_and_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[City], [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT DISTINCT [c0].[CustomerID], [c0].[City]
    FROM [Customers] AS [c0]
    INNER JOIN [Orders] AS [o0] ON [c0].[CustomerID] = [o0].[CustomerID]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[City], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_on_join_clause_with_order_by_and_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[City], [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT DISTINCT [c0].[CustomerID], [c0].[City]
    FROM [Customers] AS [c0]
    INNER JOIN [Orders] AS [o0] ON [c0].[CustomerID] = [o0].[CustomerID]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[City], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_dependent_already_tracked_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_dependent_already_tracked_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Where_subquery_on_navigation_client_eval() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [o4].[OrderID]
FROM [Orders] AS [o4]",
                //
                @"@_outer_CustomerID='ALFKI' (Size = 255)

SELECT [o2].[OrderID]
FROM [Orders] AS [o2]
WHERE @_outer_CustomerID = [o2].[CustomerID]",
                //
                @"SELECT [o4].[OrderID]
FROM [Orders] AS [o4]",
                //
                @"@_outer_CustomerID='ANATR' (Size = 255)

SELECT [o2].[OrderID]
FROM [Orders] AS [o2]
WHERE @_outer_CustomerID = [o2].[CustomerID]",
                //
                @"SELECT [o4].[OrderID]
FROM [Orders] AS [o4]",
                //
                @"@_outer_CustomerID='ANTON' (Size = 255)

SELECT [o2].[OrderID]
FROM [Orders] AS [o2]
WHERE @_outer_CustomerID = [o2].[CustomerID]",
                //
                @"SELECT [o4].[OrderID]
FROM [Orders] AS [o4]",
                //
                @"@_outer_CustomerID='AROUT' (Size = 255)

SELECT [o2].[OrderID]
FROM [Orders] AS [o2]
WHERE @_outer_CustomerID = [o2].[CustomerID]");

Output truncated.

EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Collection_select_nav_prop_first_or_default_then_nav_prop() : 
            AssertSql(
                @"SELECT [e].[CustomerID]
FROM [Customers] AS [e]
WHERE [e].[CustomerID] LIKE 'A' + '%' AND (LEFT([e].[CustomerID], LEN('A')) = 'A')
ORDER BY [e].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Size = 255)

SELECT TOP 1 [e#Customer].[CustomerID], [e#Customer].[Address], [e#Customer].[City], [e#Customer].[CompanyName], [e#Customer].[ContactName], [e#Customer].[ContactTitle], [e#Customer].[Country], [e#Customer].[Fax], [e#Customer].[Phone], [e#Customer].[PostalCode], [e#Customer].[Region]
FROM [Orders] AS [e0]
LEFT JOIN [Customers] AS [e#Customer] ON [e0].[CustomerID] = [e#Customer].[CustomerID]
WHERE [e0].[OrderID] IN (10643, 10692, 10702, 10835, 10952, 11011) AND (@_outer_CustomerID = [e0].[CustomerID])",
                //
                @"@_outer_CustomerID='ANATR' (Size = 255)

SELECT TOP 1 [e#Customer].[CustomerID], [e#Customer].[Address], [e#Customer].[City], [e#Customer].[CompanyName], [e#Customer].[ContactName], [e#Customer].[ContactTitle], [e#Customer].[Country], [e#Customer].[Fax], [e#Customer].[Phone], [e#Customer].[PostalCode], [e#Customer].[Region]
FROM [Orders] AS [e0]
LEFT JOIN [Customers] AS [e#Customer] ON [e0].[CustomerID] = [e#Customer].[CustomerID]
WHERE [e0].[OrderID] IN (10643, 10692, 10702, 10835, 10952, 11011) AND (@_outer_CustomerID = [e0].[CustomerID])",
                //
                @"@_outer_CustomerID='ANTON' (Size = 255)

SELECT TOP 1 [e#Customer].[CustomerID], [e#Customer].[Address], [e#Customer].[City], [e#Customer].[CompanyName], [e#Customer].[ContactName], [e#Customer].[ContactTitle], [e#Customer].[Country], [e#Customer].[Fax], [e#Customer].[Phone], [e#Customer].[PostalCode], [e#Customer].[Region]
FROM [Orders] AS [e0]
LEFT JOIN [Customers] AS [e#Customer] ON [e0].[CustomerID] = [e#Customer].[CustomerID]
WHERE [e0].[OrderID] IN (10643, 10692, 10702, 10835, 10952, 11011) AND (@_outer_CustomerID = [e0].[CustomerID])",
                //
                @"@_outer_CustomerID='AROUT' (Size = 255)

SELECT TOP 1 [e#Customer].[CustomerID], [e#Customer].[Address], [e#Customer].[City], [e#Customer].[CompanyName], [e#Customer].[ContactName], [e#Customer].[ContactTitle], [e#Customer].[Country], [e#Customer].[Fax], [e#Customer].[Phone], [e#Customer].[PostalCode], [e#Customer].[Region]
FROM [Orders] AS [e0]
LEFT JOIN [Customers] AS [e#Customer] ON [e0].[CustomerID] = [e#Customer].[CustomerID]
WHERE [e0].[OrderID] IN (10643, 10692, 10702, 10835, 10952, 11011) AND (@_outer_CustomerID = [e0].[CustomerID])");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Navigation_fk_based_inside_contains() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] IN ('ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Collection_where_nav_prop_all() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE NOT EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE ([c].[CustomerID] = [o].[CustomerID]) AND (([o].[CustomerID] <> 'ALFKI') OR [o].[CustomerID] IS NULL))");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.GroupBy_on_nav_prop() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[City]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
ORDER BY [o#Customer].[City]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Compare_simple_zero() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <> 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] > 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <= 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] > 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <= 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_Where_Count_with_predicate_client_eval_mixed() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE ([o].[CustomerID] <> 'ALFKI') OR [o].[CustomerID] IS NULL");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_StartsWith_Column() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ([c].[ContactName] LIKE [c].[ContactName] + '%' AND (LEFT([c].[ContactName], LEN([c].[ContactName])) = [c].[ContactName])) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Join_with_nav_projected_in_subquery_when_client_eval() : 
            AssertSql(
                @"SELECT [od0].[OrderID], [od0].[ProductID], [od0].[Discount], [od0].[Quantity], [od0].[UnitPrice], [od#Product0].[ProductID], [od#Product0].[Discontinued], [od#Product0].[ProductName], [od#Product0].[UnitPrice], [od#Product0].[UnitsInStock]
FROM [Order Details] AS [od0]
INNER JOIN [Products] AS [od#Product0] ON [od0].[ProductID] = [od#Product0].[ProductID]",
                //
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [o#Customer0].[CustomerID], [o#Customer0].[Address], [o#Customer0].[City], [o#Customer0].[CompanyName], [o#Customer0].[ContactName], [o#Customer0].[ContactTitle], [o#Customer0].[Country], [o#Customer0].[Fax], [o#Customer0].[Phone], [o#Customer0].[PostalCode], [o#Customer0].[Region]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_client_and_server_top_level() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <> 'AROUT'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_shadow() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[Title] = 'Sales Representative'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_project_filter() : 
            AssertSql(
                @"SELECT [c].[CompanyName]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_dependent_already_tracked(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_StartsWith_MethodCall() : 
            AssertSql(
                @"@__LocalMethod1_0='M' (Size = 4000)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ([c].[ContactName] LIKE @__LocalMethod1_0 + '%' AND (LEFT([c].[ContactName], LEN(@__LocalMethod1_0)) = @__LocalMethod1_0)) OR (@__LocalMethod1_0 = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.First_inside_subquery_gets_client_evaluated() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'",
                //
                @"@_outer_CustomerID='ALFKI' (Size = 255)

SELECT TOP 1 [o0].[CustomerID]
FROM [Orders] AS [o0]
WHERE ([o0].[CustomerID] = 'ALFKI') AND (@_outer_CustomerID = [o0].[CustomerID])");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_Count_with_predicate() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition4() : 
            AssertSql(
                @"@__p_0='2'

SELECT [t].[CustomerID], [t].[Address], [t].[City], [t].[CompanyName], [t].[ContactName], [t].[ContactTitle], [t].[Country], [t].[Fax], [t].[Phone], [t].[PostalCode], [t].[Region]
FROM (
    SELECT TOP @__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
    FROM [Customers] AS [c]
    ORDER BY [c].[CustomerID]
) AS [t]",
                //
                @"SELECT 1
FROM [Customers] AS [c0]
ORDER BY [c0].[CustomerID]",
                //
                @"SELECT [c2].[CustomerID], [c2].[Address], [c2].[City], [c2].[CompanyName], [c2].[ContactName], [c2].[ContactTitle], [c2].[Country], [c2].[Fax], [c2].[Phone], [c2].[PostalCode], [c2].[Region]
FROM [Customers] AS [c2]",
                //
                @"SELECT 1
FROM [Customers] AS [c0]
ORDER BY [c0].[CustomerID]",
                //
                @"SELECT [c2].[CustomerID], [c2].[Address], [c2].[City], [c2].[CompanyName], [c2].[ContactName], [c2].[ContactTitle], [c2].[Country], [c2].[Fax], [c2].[Phone], [c2].[PostalCode], [c2].[Region]
FROM [Customers] AS [c2]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_equals_method_string() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_dependent_already_tracked(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_on_join_clause_with_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT DISTINCT [c0].[CustomerID]
    FROM [Customers] AS [c0]
    INNER JOIN [Orders] AS [o0] ON [c0].[CustomerID] = [o0].[CustomerID]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_collection_navigation_simple() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] LIKE 'A' + '%' AND (LEFT([c0].[CustomerID], LEN('A')) = 'A')
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.GroupJoin_Where_OrderBy() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE ([o].[CustomerID] = 'ALFKI') OR ([c].[CustomerID] = 'ANATR')
ORDER BY [c].[City]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_Subquery_Single() : 
            AssertSql(
                @"@__p_0='2'

SELECT TOP @__p_0 [od].[OrderID]
FROM [Order Details] AS [od]
ORDER BY [od].[ProductID], [od].[OrderID]",
                //
                @"@_outer_OrderID='10285'

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_OrderID = [o].[OrderID]
ORDER BY [o].[OrderID]",
                //
                @"@_outer_OrderID='10294'

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_OrderID = [o].[OrderID]
ORDER BY [o].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Take_Distinct_Count() : 
            AssertSql(
                @"@__p_0='5'

SELECT COUNT(*)
FROM (
    SELECT DISTINCT [t].*
    FROM (
        SELECT TOP @__p_0 [o].*
        FROM [Orders] AS [o]
    ) AS [t]
) AS [t0]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_expression_int_to_string() : 
            AssertSql(
                @"SELECT Str([o].[OrderID]) AS [ShipName]
FROM [Orders] AS [o]
WHERE [o].[OrderDate] IS NOT NULL");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition_is_null() : 
            AssertSql(
                @"@__p_0='3'

SELECT [t].[EmployeeID], [t].[City], [t].[Country], [t].[FirstName], [t].[ReportsTo], [t].[Title]
FROM (
    SELECT TOP @__p_0 [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
    FROM [Employees] AS [e]
) AS [t]",
                //
                @"@_outer_ReportsTo='2' (Nullable = true)

SELECT TOP 2 [e2].[EmployeeID], [e2].[City], [e2].[Country], [e2].[FirstName], [e2].[ReportsTo], [e2].[Title]
FROM [Employees] AS [e2]
WHERE [e2].[EmployeeID] = @_outer_ReportsTo",
                //
                @"SELECT TOP 2 [e2].[EmployeeID], [e2].[City], [e2].[Country], [e2].[FirstName], [e2].[ReportsTo], [e2].[Title]
FROM [Employees] AS [e2]
WHERE [e2].[EmployeeID] IS NULL",
                //
                @"@_outer_ReportsTo='2' (Nullable = true)

SELECT TOP 2 [e2].[EmployeeID], [e2].[City], [e2].[Country], [e2].[FirstName], [e2].[ReportsTo], [e2].[Title]
FROM [Employees] AS [e2]
WHERE [e2].[EmployeeID] = @_outer_ReportsTo");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Collection_where_nav_prop_all_client() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Size = 255)

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='ANATR' (Size = 255)

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='ANTON' (Size = 255)

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='AROUT' (Size = 255)

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='BERGS' (Size = 255)

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='BLAUS' (Size = 255)

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='BLONP' (Size = 255)

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='BOLID' (Size = 255)

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]");

Output truncated.

EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Navigations_Where_Navigations() : 
            AssertSql(
                @"SELECT [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE ([o#Customer].[City] = 'Seattle') AND (([o#Customer].[Phone] <> '555 555 5555') OR [o#Customer].[Phone] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_conditional_operator() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY IIf(
    [c].[Region] IS NULL,
    'ZZ',
    [c].[Region]
)");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Singleton_Navigation_With_Member_Access() : 
            AssertSql(
                @"SELECT [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City] AS [B], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE ([o#Customer].[City] = 'Seattle') AND (([o#Customer].[Phone] <> '555 555 5555') OR [o#Customer].[Phone] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Navigation() : 
            AssertSql(
                @"SELECT [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_then_include_collection(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID], [c#Orders].[OrderID]",
                //
                @"SELECT [c#Orders#OrderDetails].[OrderID], [c#Orders#OrderDetails].[ProductID], [c#Orders#OrderDetails].[Discount], [c#Orders#OrderDetails].[Quantity], [c#Orders#OrderDetails].[UnitPrice]
FROM [Order Details] AS [c#Orders#OrderDetails]
INNER JOIN (
    SELECT DISTINCT [c#Orders0].[OrderID], [t0].[CustomerID]
    FROM [Orders] AS [c#Orders0]
    INNER JOIN (
        SELECT [c1].[CustomerID]
        FROM [Customers] AS [c1]
    ) AS [t0] ON [c#Orders0].[CustomerID] = [t0].[CustomerID]
) AS [t1] ON [c#Orders#OrderDetails].[OrderID] = [t1].[OrderID]
ORDER BY [t1].[CustomerID], [t1].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_collection_complex_predicate_not_matching_ins2() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI') AND [c].[CustomerID] NOT IN ('ALFKI', 'ABCDE')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Contains_Column() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (Instr([c].[ContactName], [c].[ContactName]) > 0) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Anonymous_member_distinct_where() : 
            AssertSql(
                @"SELECT [t].[CustomerID]
FROM (
    SELECT DISTINCT [c].[CustomerID]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Contains_Identity() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (Instr([c].[ContactName], [c].[ContactName]) > 0) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_reversed() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE 'London' = [c].[City]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_concat_with_navigation2() : 
            AssertSql(
                @"SELECT ([o#Customer].[City] + ' ') + [o#Customer].[City]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Join_with_nav_in_orderby_in_subquery_when_client_eval() : 
            AssertSql(
                @"SELECT [od0].[OrderID], [od0].[ProductID], [od0].[Discount], [od0].[Quantity], [od0].[UnitPrice], [od#Product0].[ProductID], [od#Product0].[Discontinued], [od#Product0].[ProductName], [od#Product0].[UnitPrice], [od#Product0].[UnitsInStock]
FROM [Order Details] AS [od0]
INNER JOIN [Products] AS [od#Product0] ON [od0].[ProductID] = [od#Product0].[ProductID]",
                //
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [o#Customer0].[CustomerID], [o#Customer0].[Address], [o#Customer0].[City], [o#Customer0].[CompanyName], [o#Customer0].[ContactName], [o#Customer0].[ContactTitle], [o#Customer0].[Country], [o#Customer0].[Fax], [o#Customer0].[Phone], [o#Customer0].[PostalCode], [o#Customer0].[Region]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Where_Navigation_Contains() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE Instr([o#Customer].[City], 'Sea') > 0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_Where_Count() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_EndsWith_Literal() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE RIGHT([c].[ContactName], LEN('b')) = 'b'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_order_by_non_key_with_first_or_default(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CompanyName] DESC, [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID], [c0].[CompanyName]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CompanyName] DESC, [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CompanyName] DESC, [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_order_by_non_key_with_first_or_default(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CompanyName] DESC, [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID], [c0].[CompanyName]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CompanyName] DESC, [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CompanyName] DESC, [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_with_filter_reordered(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_with_filter_reordered(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Where_nav_prop_group_by() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
INNER JOIN [Orders] AS [od#Order] ON [od].[OrderID] = [od#Order].[OrderID]
WHERE [od#Order].[CustomerID] = 'ALFKI'
ORDER BY [od].[Quantity]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Collection_select_nav_prop_single_or_default_then_nav_prop_nested() : 
            AssertSql(
                @"SELECT 1
FROM [Customers] AS [e]
WHERE [e].[CustomerID] LIKE 'A' + '%' AND (LEFT([e].[CustomerID], LEN('A')) = 'A')",
                //
                @"SELECT TOP 2 [o#Customer0].[City]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]
WHERE [o0].[OrderID] = 10643",
                //
                @"SELECT TOP 2 [o#Customer0].[City]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]
WHERE [o0].[OrderID] = 10643",
                //
                @"SELECT TOP 2 [o#Customer0].[City]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]
WHERE [o0].[OrderID] = 10643",
                //
                @"SELECT TOP 2 [o#Customer0].[City]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]
WHERE [o0].[OrderID] = 10643");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_collection_FirstOrDefault_project_entity() : 
            AssertSql(
                @"@__p_0='2'

SELECT TOP @__p_0 [c].[CustomerID]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Size = 255)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='ANATR' (Size = 255)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_take_no_order_by(Boolean useString) : 
            AssertSql(
                @"@__p_0='10'

SELECT TOP @__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@__p_0='10'

SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP @__p_0 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_take_no_order_by(Boolean useString) : 
            AssertSql(
                @"@__p_0='10'

SELECT TOP @__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@__p_0='10'

SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP @__p_0 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Singleton_Navigation_With_Member_Access() : 
            AssertSql(
                @"SELECT [o#Customer].[City] AS [B]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE ([o#Customer].[City] = 'Seattle') AND (([o#Customer].[Phone] <> '555 555 5555') OR [o#Customer].[Phone] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested_negated3() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE NOT EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A')) AND (([c].[City] <> 'London') OR [c].[City] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_subquery_involving_join_binds_to_correct_table() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE ([o].[OrderID] > 11000) AND [o].[OrderID] IN (
    SELECT [od].[OrderID]
    FROM [Order Details] AS [od]
    INNER JOIN [Products] AS [od#Product] ON [od].[ProductID] = [od#Product].[ProductID]
    WHERE [od#Product].[ProductName] = 'Chai'
)");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_filter_reordered(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_filter_reordered(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A'))");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.GroupJoin_with_nav_in_predicate_in_subquery_when_client_eval() : 
            AssertSql(
                @"SELECT [od0].[OrderID], [od0].[ProductID], [od0].[Discount], [od0].[Quantity], [od0].[UnitPrice], [od#Product0].[ProductID], [od#Product0].[Discontinued], [od#Product0].[ProductName], [od#Product0].[UnitPrice], [od#Product0].[UnitsInStock]
FROM [Order Details] AS [od0]
INNER JOIN [Products] AS [od#Product0] ON [od0].[ProductID] = [od#Product0].[ProductID]",
                //
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [o#Customer0].[CustomerID], [o#Customer0].[Address], [o#Customer0].[City], [o#Customer0].[CompanyName], [o#Customer0].[ContactName], [o#Customer0].[ContactTitle], [o#Customer0].[Country], [o#Customer0].[Fax], [o#Customer0].[Phone], [o#Customer0].[PostalCode], [o#Customer0].[Region]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Project_single_entity_value_subquery_works() : 
            AssertSql(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Size = 255)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]
ORDER BY [o].[OrderID]",
                //
                @"@_outer_CustomerID='ANATR' (Size = 255)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]
ORDER BY [o].[OrderID]",
                //
                @"@_outer_CustomerID='ANTON' (Size = 255)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]
ORDER BY [o].[OrderID]",
                //
                @"@_outer_CustomerID='AROUT' (Size = 255)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]
ORDER BY [o].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition2() : 
            AssertSql(
                @"@__p_0='3'

SELECT [t].[EmployeeID], [t].[City], [t].[Country], [t].[FirstName], [t].[ReportsTo], [t].[Title]
FROM (
    SELECT TOP @__p_0 [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
    FROM [Employees] AS [e]
) AS [t]",
                //
                @"SELECT TOP 1 [e0].[EmployeeID], [e0].[City], [e0].[Country], [e0].[FirstName], [e0].[ReportsTo], [e0].[Title]
FROM [Employees] AS [e0]
ORDER BY [e0].[EmployeeID]",
                //
                @"SELECT TOP 1 [e0].[EmployeeID], [e0].[City], [e0].[Country], [e0].[FirstName], [e0].[ReportsTo], [e0].[Title]
FROM [Employees] AS [e0]
ORDER BY [e0].[EmployeeID]",
                //
                @"SELECT TOP 1 [e0].[EmployeeID], [e0].[City], [e0].[Country], [e0].[FirstName], [e0].[ReportsTo], [e0].[Title]
FROM [Employees] AS [e0]
ORDER BY [e0].[EmployeeID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_correlated_subquery_ordered() : 
            AssertSql(
                @"@__p_0='3'

SELECT TOP @__p_0 [c].[CustomerID]
FROM [Customers] AS [c]",
                //
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]",
                //
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]",
                //
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]",
                //
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]",
                //
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]",
                //
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.GroupJoin_with_nav_in_orderby_in_subquery_when_client_eval() : 
            AssertSql(
                @"SELECT [od0].[OrderID], [od0].[ProductID], [od0].[Discount], [od0].[Quantity], [od0].[UnitPrice], [od#Product0].[ProductID], [od#Product0].[Discontinued], [od#Product0].[ProductName], [od#Product0].[UnitPrice], [od#Product0].[UnitsInStock]
FROM [Order Details] AS [od0]
INNER JOIN [Products] AS [od#Product0] ON [od0].[ProductID] = [od#Product0].[ProductID]",
                //
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [o#Customer0].[CustomerID], [o#Customer0].[Address], [o#Customer0].[City], [o#Customer0].[CompanyName], [o#Customer0].[ContactName], [o#Customer0].[ContactTitle], [o#Customer0].[Country], [o#Customer0].[Fax], [o#Customer0].[Phone], [o#Customer0].[PostalCode], [o#Customer0].[Region]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Take_Select_Navigation() : 
            AssertSql(
                @"@__p_0='2'

SELECT TOP @__p_0 [c].[CustomerID]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Size = 255)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='ANATR' (Size = 255)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_take_max() : 
            AssertSql(
                @"@__p_0='10'

SELECT MAX([t].[OrderID])
FROM (
    SELECT TOP @__p_0 [o].[OrderID]
    FROM [Orders] AS [o]
    ORDER BY [o].[OrderID]
) AS [t]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Let_group_by_nav_prop() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice], [od#Order].[CustomerID] AS [customer]
FROM [Order Details] AS [od]
INNER JOIN [Orders] AS [od#Order] ON [od].[OrderID] = [od#Order].[OrderID]
ORDER BY [od#Order].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Where_Navigation_Included() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o#Customer].[City] = 'Seattle'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_list_inline() : line() in C:\Develop\ForPlanning\EntityFrameworkCore.Jet\test\EFCore.Jet.FunctionalTests\QueryJetTest.cs:riga 6234
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.IsNullOrEmpty_in_predicate() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[Region] IS NULL OR ([c].[Region] = '')");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Join_with_nav_in_predicate_in_subquery_when_client_eval() : 
            AssertSql(
                @"SELECT [od0].[OrderID], [od0].[ProductID], [od0].[Discount], [od0].[Quantity], [od0].[UnitPrice], [od#Product0].[ProductID], [od#Product0].[Discontinued], [od#Product0].[ProductName], [od#Product0].[UnitPrice], [od#Product0].[UnitsInStock]
FROM [Order Details] AS [od0]
INNER JOIN [Products] AS [od#Product0] ON [od0].[ProductID] = [od#Product0].[ProductID]",
                //
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [o#Customer0].[CustomerID], [o#Customer0].[Address], [o#Customer0].[City], [o#Customer0].[CompanyName], [o#Customer0].[ContactName], [o#Customer0].[ContactTitle], [o#Customer0].[Country], [o#Customer0].[Fax], [o#Customer0].[Phone], [o#Customer0].[PostalCode], [o#Customer0].[Region]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Where_Navigation_Client() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Navigation_inside_contains() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o#Customer].[City] IN ('Novigrad', 'Seattle')");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_collection_FirstOrDefault_project_anonymous_type() : 
            AssertSql(
                @"@__p_0='2'

SELECT TOP @__p_0 [c].[CustomerID]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Size = 255)

SELECT TOP 1 [o].[CustomerID], [o].[OrderID]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='ANATR' (Size = 255)

SELECT TOP 1 [o].[CustomerID], [o].[OrderID]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Where_Navigation_Multiple_Access() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE ([o#Customer].[City] = 'Seattle') AND (([o#Customer].[Phone] <> '555 555 5555') OR [o#Customer].[Phone] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Collection_select_nav_prop_first_or_default() : 
            AssertSql(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Size = 255)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='ANATR' (Size = 255)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='ANTON' (Size = 255)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='AROUT' (Size = 255)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='BERGS' (Size = 255)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='BLAUS' (Size = 255)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='BLONP' (Size = 255)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='BOLID' (Size = 255)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]");

Output truncated.

EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_and_collection(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
ORDER BY [o].[OrderID]",
                //
                @"SELECT [o#OrderDetails].[OrderID], [o#OrderDetails].[ProductID], [o#OrderDetails].[Discount], [o#OrderDetails].[Quantity], [o#OrderDetails].[UnitPrice]
FROM [Order Details] AS [o#OrderDetails]
INNER JOIN (
    SELECT DISTINCT [o0].[OrderID]
    FROM [Orders] AS [o0]
    LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]
) AS [t] ON [o#OrderDetails].[OrderID] = [t].[OrderID]
ORDER BY [t].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Join_customers_orders_with_subquery_anonymous_property_method_with_take() : 
            AssertSql(
                @"@__p_0='5'

SELECT [t].[OrderID], [t].[CustomerID], [t].[EmployeeID], [t].[OrderDate]
FROM (
    SELECT TOP @__p_0 [o2].[OrderID], [o2].[CustomerID], [o2].[EmployeeID], [o2].[OrderDate]
    FROM [Orders] AS [o2]
    ORDER BY [o2].[OrderID]
) AS [t]",
                //
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Take_simple() : 
            AssertSql(
                @"@__p_0='10'

SELECT TOP @__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_when_groupby(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[City], [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID], [c0].[City]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[City], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_when_groupby(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[City], [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID], [c0].[City]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[City], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_last_no_orderby(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID] DESC",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CustomerID] DESC
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID] DESC");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_last_no_orderby(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID] DESC",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CustomerID] DESC
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID] DESC");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Collection_select_nav_prop_all_client() : 
            AssertSql(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Size = 255)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='ANATR' (Size = 255)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='ANTON' (Size = 255)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='AROUT' (Size = 255)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='BERGS' (Size = 255)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='BLAUS' (Size = 255)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='BLONP' (Size = 255)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='BOLID' (Size = 255)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]");

Output truncated.

EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Where_Navigation_Null_Deep() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
LEFT JOIN [Employees] AS [e#Manager] ON [e].[ReportsTo] = [e#Manager].[EmployeeID]
WHERE [e#Manager].[ReportsTo] IS NULL");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_order_by_non_key(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[City], [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID], [c0].[City]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[City], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_order_by_non_key(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[City], [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID], [c0].[City]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[City], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_principal_already_tracked_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_principal_already_tracked_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_dependent_already_tracked(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_dependent_already_tracked(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested_negated2() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (([c].[City] <> 'London') OR [c].[City] IS NULL) AND NOT EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A'))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Take_subquery_projection() : 
            AssertSql(
                @"@__p_0='2'

SELECT TOP @__p_0 [c].[City]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_negated_twice() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition_entity_equality_one_element_SingleOrDefault() : 
            AssertSql(
                @"@__p_0='3'

SELECT [t].[EmployeeID], [t].[City], [t].[Country], [t].[FirstName], [t].[ReportsTo], [t].[Title]
FROM (
    SELECT TOP @__p_0 [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
    FROM [Employees] AS [e]
) AS [t]",
                //
                @"@_outer_ReportsTo='2' (Nullable = true)

SELECT TOP 2 [e20].[EmployeeID]
FROM [Employees] AS [e20]
WHERE [e20].[EmployeeID] = @_outer_ReportsTo",
                //
                @"SELECT TOP 2 [e20].[EmployeeID]
FROM [Employees] AS [e20]
WHERE [e20].[EmployeeID] IS NULL",
                //
                @"@_outer_ReportsTo='2' (Nullable = true)

SELECT TOP 2 [e20].[EmployeeID]
FROM [Employees] AS [e20]
WHERE [e20].[EmployeeID] = @_outer_ReportsTo");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Anonymous_complex_distinct_result() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM (
    SELECT DISTINCT [c].[CustomerID] + [c].[City] AS [A]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[A] LIKE 'A' + '%' AND (LEFT([t].[A], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Take_OrderBy_Count() : 
            AssertSql(
                @"@__p_0='5'

SELECT COUNT(*)
FROM (
    SELECT TOP @__p_0 [o].*
    FROM [Orders] AS [o]
) AS [t]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Substring_with_client_eval() : 
            AssertSql(
                @"SELECT TOP 1 [c].[ContactName]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_conditional_order_by(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY IIf(
    [c].[CustomerID] LIKE 'S' + '%' AND (LEFT([c].[CustomerID], LEN('S')) = 'S'),
    1,
    2
), [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID], IIf(
        [c0].[CustomerID] LIKE 'S' + '%' AND (LEFT([c0].[CustomerID], LEN('S')) = 'S'),
        1,
        2
    ) AS [c]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[c], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Take_with_single() : 
            AssertSql(
                @"@__p_0='1'

SELECT TOP 2 [t].*
FROM (
    SELECT TOP @__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
    FROM [Customers] AS [c]
    ORDER BY [c].[CustomerID]
) AS [t]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_conditional_order_by(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY IIf(
    [c].[CustomerID] LIKE 'S' + '%' AND (LEFT([c].[CustomerID], LEN('S')) = 'S'),
    1,
    2
), [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID], IIf(
        [c0].[CustomerID] LIKE 'S' + '%' AND (LEFT([c0].[CustomerID], LEN('S')) = 'S'),
        1,
        2
    ) AS [c]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[c], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_parameter() : 
            AssertSql(
                @"@__prm_0='True'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE @__prm_0 = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_concat_with_navigation1() : 
            AssertSql(
                @"SELECT ([o].[CustomerID] + ' ') + [o#Customer].[City]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.DTO_member_distinct_where() : 
            AssertSql(
                @"SELECT [t].[Property]
FROM (
    SELECT DISTINCT [c].[CustomerID] AS [Property]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[Property] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_order_by_key(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Queryable_simple_anonymous_subquery() : 
            AssertSql(
                @"@__p_0='91'

SELECT TOP @__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_as_no_tracking2(Boolean useString) : 
            AssertSql(
                @"@__p_0='5'

SELECT TOP @__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@__p_0='5'

SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP @__p_0 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_as_no_tracking2(Boolean useString) : 
            AssertSql(
                @"@__p_0='5'

SELECT TOP @__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@__p_0='5'

SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP @__p_0 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_orderBy_take_count() : 
            AssertSql(
                @"@__p_0='7'

SELECT COUNT(*)
FROM (
    SELECT TOP @__p_0 [c].*
    FROM [Customers] AS [c]
    ORDER BY [c].[Country]
) AS [t]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_principal_already_tracked(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_shadow_subquery_FirstOrDefault() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[Title] = (
    SELECT TOP 1 [e2].[Title]
    FROM [Employees] AS [e2]
    ORDER BY [e2].[Title]
)");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_with_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Join_Where_Count() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_take_min() : 
            AssertSql(
                @"@__p_0='10'

SELECT MIN([t].[OrderID])
FROM (
    SELECT TOP @__p_0 [o].[OrderID]
    FROM [Orders] AS [o]
    ORDER BY [o].[OrderID]
) AS [t]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_false() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_with_skip(Boolean useString) : 
            AssertSql(
                @"@__p_0='80'

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactName], [c].[CustomerID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_with_skip(Boolean useString) : 
            AssertSql(
                @"@__p_0='80'

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactName], [c].[CustomerID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.DTO_member_distinct_result() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM (
    SELECT DISTINCT [c].[CustomerID] AS [Property]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[Property] LIKE 'A' + '%' AND (LEFT([t].[Property], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_multi_level_reference_and_collection_predicate(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 2 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o].[OrderID] = 10248
ORDER BY [o#Customer].[CustomerID]",
                //
                @"SELECT [o#Customer#Orders].[OrderID], [o#Customer#Orders].[CustomerID], [o#Customer#Orders].[EmployeeID], [o#Customer#Orders].[OrderDate]
FROM [Orders] AS [o#Customer#Orders]
INNER JOIN (
    SELECT DISTINCT [t].*
    FROM (
        SELECT TOP 1 [o#Customer0].[CustomerID]
        FROM [Orders] AS [o0]
        LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]
        WHERE [o0].[OrderID] = 10248
        ORDER BY [o#Customer0].[CustomerID]
    ) AS [t]
) AS [t0] ON [o#Customer#Orders].[CustomerID] = [t0].[CustomerID]
ORDER BY [t0].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_multi_level_reference_and_collection_predicate(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 2 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o].[OrderID] = 10248
ORDER BY [o#Customer].[CustomerID]",
                //
                @"SELECT [o#Customer#Orders].[OrderID], [o#Customer#Orders].[CustomerID], [o#Customer#Orders].[EmployeeID], [o#Customer#Orders].[OrderDate]
FROM [Orders] AS [o#Customer#Orders]
INNER JOIN (
    SELECT DISTINCT [t].*
    FROM (
        SELECT TOP 1 [o#Customer0].[CustomerID]
        FROM [Orders] AS [o0]
        LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]
        WHERE [o0].[OrderID] = 10248
        ORDER BY [o#Customer0].[CustomerID]
    ) AS [t]
) AS [t0] ON [o#Customer#Orders].[CustomerID] = [t0].[CustomerID]
ORDER BY [t0].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_EndsWith_Identity() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (RIGHT([c].[ContactName], LEN([c].[ContactName])) = [c].[ContactName]) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_de_morgan_and_optimizated() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE ([p].[Discontinued] = False) OR ([p].[ProductID] >= 20)");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Local_array() : 
            AssertSql(
                @"@__get_Item_0='ALFKI' (Size = 255)

SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = @__get_Item_0");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_order_by_non_key_with_take(Boolean useString) : 
            AssertSql(
                @"@__p_0='10'

SELECT TOP @__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactTitle], [c].[CustomerID]",
                //
                @"@__p_0='10'

SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP @__p_0 [c0].[CustomerID], [c0].[ContactTitle]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[ContactTitle], [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[ContactTitle], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_order_by_non_key_with_take(Boolean useString) : 
            AssertSql(
                @"@__p_0='10'

SELECT TOP @__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactTitle], [c].[CustomerID]",
                //
                @"@__p_0='10'

SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP @__p_0 [c0].[CustomerID], [c0].[ContactTitle]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[ContactTitle], [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[ContactTitle], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_last(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CompanyName] DESC, [c].[CustomerID] DESC",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID], [c0].[CompanyName]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CompanyName] DESC, [c0].[CustomerID] DESC
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CompanyName] DESC, [t].[CustomerID] DESC");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_last(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CompanyName] DESC, [c].[CustomerID] DESC",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID], [c0].[CompanyName]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CompanyName] DESC, [c0].[CustomerID] DESC
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CompanyName] DESC, [t].[CustomerID] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_expression_long_to_string() : 
            AssertSql(
                @"SELECT Str([o].[OrderID]) AS [ShipName]
FROM [Orders] AS [o]
WHERE [o].[OrderDate] IS NOT NULL");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_with_take(Boolean useString) : 
            AssertSql(
                @"@__p_0='10'

SELECT TOP @__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[City] DESC, [c].[CustomerID]",
                //
                @"@__p_0='10'

SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP @__p_0 [c0].[CustomerID], [c0].[City]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[City] DESC, [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[City] DESC, [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Distinct_Take() : 
            AssertSql(
                @"@__p_0='5'

SELECT TOP @__p_0 [t].[OrderID], [t].[CustomerID], [t].[EmployeeID], [t].[OrderDate]
FROM (
    SELECT DISTINCT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
    FROM [Orders] AS [o]
) AS [t]
ORDER BY [t].[OrderID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_where_skip_take_projection(Boolean useString) : 
            AssertSql(
                @"@__p_1='2'
@__p_0='1'

SELECT TOP @__p_1+@__p_0 [od#Order].[CustomerID]
FROM [Order Details] AS [od]
INNER JOIN [Orders] AS [od#Order] ON [od].[OrderID] = [od#Order].[OrderID]
WHERE [od].[Quantity] = 10
ORDER BY [od].[OrderID], [od].[ProductID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_where_skip_take_projection(Boolean useString) : 
            AssertSql(
                @"@__p_1='2'
@__p_0='1'

SELECT TOP @__p_1+@__p_0 [od#Order].[CustomerID]
FROM [Order Details] AS [od]
INNER JOIN [Orders] AS [od#Order] ON [od].[OrderID] = [od#Order].[OrderID]
WHERE [od].[Quantity] = 10
ORDER BY [od].[OrderID], [od].[ProductID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested3() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A')) AND (([c].[City] <> 'London') OR [c].[City] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_EndsWith_MethodCall() : 
            AssertSql(
                @"@__LocalMethod2_0='m' (Size = 4000)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (RIGHT([c].[ContactName], LEN(@__LocalMethod2_0)) = @__LocalMethod2_0) OR (@__LocalMethod2_0 = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_expression_invoke() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition2_FirstOrDefault() : 
            AssertSql(
                @"@__p_0='3'

SELECT [t].[EmployeeID], [t].[City], [t].[Country], [t].[FirstName], [t].[ReportsTo], [t].[Title]
FROM (
    SELECT TOP @__p_0 [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
    FROM [Employees] AS [e]
) AS [t]
WHERE [t].[FirstName] = (
    SELECT TOP 1 [e0].[FirstName]
    FROM [Employees] AS [e0]
    ORDER BY [e0].[EmployeeID]
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Anonymous_member_distinct_result() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM (
    SELECT DISTINCT [c].[CustomerID]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[CustomerID] LIKE 'A' + '%' AND (LEFT([t].[CustomerID], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Join_Customers_Orders_Projection_With_String_Concat_Skip_Take() : 
            AssertSql(
                @"@__p_1='5'
@__p_0='10'

SELECT TOP @__p_1+@__p_0 ([c].[ContactName] + ' ') + [c].[ContactTitle] AS [Contact], [o].[OrderID]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
ORDER BY [o].[OrderID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_compared_to_binary_expression() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = IIf(
    [p].[ProductID] > 50,
    True,
    False
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Null_conditional_simple() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_comparison_to_nullable_bool() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE RIGHT([c].[CustomerID], LEN('KI')) = 'KI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_subquery_and_local_array_closure() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Customers] AS [c1]
    WHERE [c1].[City] IN ('London', 'Buenos Aires') AND ([c1].[CustomerID] = [c].[CustomerID]))",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Customers] AS [c1]
    WHERE [c1].[City] IN ('London') AND ([c1].[CustomerID] = [c].[CustomerID]))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Distinct_Take_Count() : 
            AssertSql(
                @"@__p_0='5'

SELECT COUNT(*)
FROM (
    SELECT DISTINCT TOP @__p_0 [o].*
    FROM [Orders] AS [o]
) AS [t]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_LastOrDefault() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'
ORDER BY [c].[ContactName] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Contains_Literal() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE Instr([c].[ContactName], 'M') > 0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_equals_on_mismatched_types_nullable_int_long() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE False = True",
                //
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_ternary_boolean_condition_false() : 
            AssertSql(
                @"@__flag_0='False'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE ((@__flag_0 = True) AND ([p].[UnitsInStock] >= 20)) OR ((@__flag_0 <> True) AND ([p].[UnitsInStock] < 20))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Single_Predicate() : 
            AssertSql(
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Take_simple_parameterized() : 
            AssertSql(
                @"@__p_0='10'

SELECT TOP @__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_collection_complex_predicate_or() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI', 'ALFKI', 'ABCDE')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_with_multiple_conditions_still_uses_exists() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ([c].[City] = 'London') AND EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE ([o].[EmployeeID] = 1) AND ([c].[CustomerID] = [o].[CustomerID]))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_expression_other_to_string() : 
            AssertSql(
                @"SELECT Str([o].[OrderDate]) AS [ShipName]
FROM [Orders] AS [o]
WHERE [o].[OrderDate] IS NOT NULL");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_join_select() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_math_sin() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
WHERE ([od].[OrderID] = 11077) AND (SIN([od].[Discount]) > 0E0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_skip_take() : 
            AssertSql(
                @"@__p_1='8'
@__p_0='5'

SELECT TOP @__p_1+@__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactTitle], [c].[ContactName]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.GroupJoin_simple_subquery() : 
            AssertSql(
                @"@__p_0='4'

SELECT [t].[OrderID], [t].[CustomerID], [t].[EmployeeID], [t].[OrderDate]
FROM [Customers] AS [c]
INNER JOIN (
    SELECT TOP @__p_0 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
    FROM [Orders] AS [o]
    ORDER BY [o].[OrderID]
) AS [t] ON [c].[CustomerID] = [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_negated_boolean_expression_compared_to_another_negated_boolean_expression() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE IIf(
    [p].[ProductID] > 50,
    True,
    False
) = IIf(
    [p].[ProductID] > 20,
    True,
    False
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_StartsWith_Identity() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ([c].[ContactName] LIKE [c].[ContactName] + '%' AND (LEFT([c].[ContactName], LEN([c].[ContactName])) = [c].[ContactName])) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OfType_Select() : 
            AssertSql(
                @"SELECT TOP 1 [o#Customer].[City]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
ORDER BY [o].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.DTO_complex_distinct_where() : 
            AssertSql(
                @"SELECT [t].[Property]
FROM (
    SELECT DISTINCT [c].[CustomerID] + [c].[City] AS [Property]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[Property] = 'ALFKIBerlin'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition_is_not_null() : 
            AssertSql(
                @"@__p_0='3'

SELECT [t].[EmployeeID], [t].[City], [t].[Country], [t].[FirstName], [t].[ReportsTo], [t].[Title]
FROM (
    SELECT TOP @__p_0 [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
    FROM [Employees] AS [e]
) AS [t]",
                //
                @"@_outer_ReportsTo='2' (Nullable = true)

SELECT TOP 2 [e2].[EmployeeID], [e2].[City], [e2].[Country], [e2].[FirstName], [e2].[ReportsTo], [e2].[Title]
FROM [Employees] AS [e2]
WHERE [e2].[EmployeeID] = @_outer_ReportsTo",
                //
                @"SELECT TOP 2 [e2].[EmployeeID], [e2].[City], [e2].[Country], [e2].[FirstName], [e2].[ReportsTo], [e2].[Title]
FROM [Employees] AS [e2]
WHERE [e2].[EmployeeID] IS NULL",
                //
                @"@_outer_ReportsTo='2' (Nullable = true)

SELECT TOP 2 [e2].[EmployeeID], [e2].[City], [e2].[Country], [e2].[FirstName], [e2].[ReportsTo], [e2].[Title]
FROM [Employees] AS [e2]
WHERE [e2].[EmployeeID] = @_outer_ReportsTo");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Join_customers_orders_with_subquery_with_take() : 
            AssertSql(
                @"@__p_0='5'

SELECT [c].[ContactName], [t].[OrderID]
FROM [Customers] AS [c]
INNER JOIN (
    SELECT TOP @__p_0 [o2].*
    FROM [Orders] AS [o2]
    ORDER BY [o2].[OrderID]
) AS [t] ON [c].[CustomerID] = [t].[CustomerID]
WHERE [t].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_ternary_boolean_condition_true() : 
            AssertSql(
                @"@__flag_0='True'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE ((@__flag_0 = True) AND ([p].[UnitsInStock] >= 20)) OR ((@__flag_0 <> True) AND ([p].[UnitsInStock] < 20))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_collection_complex_predicate_not_matching_ins1() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ALFKI', 'ABCDE') OR [c].[CustomerID] NOT IN ('ABCDE', 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_client_side_negated() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Take_Where_Distinct_Count() : 
            AssertSql(
                @"@__p_0='5'

SELECT COUNT(*)
FROM (
    SELECT DISTINCT [t].*
    FROM (
        SELECT TOP @__p_0 [o].*
        FROM [Orders] AS [o]
        WHERE [o].[CustomerID] = 'FRANK'
    ) AS [t]
) AS [t0]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_nested_collection_multi_level() : 
            AssertSql(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')",
                //
                @"@_outer_CustomerID='ALFKI' (Size = 255)

SELECT TOP 3 [o].[OrderDate] AS [Date]
FROM [Orders] AS [o]
WHERE ([o].[OrderID] < 10500) AND (@_outer_CustomerID = [o].[CustomerID])",
                //
                @"@_outer_CustomerID='ANATR' (Size = 255)

SELECT TOP 3 [o].[OrderDate] AS [Date]
FROM [Orders] AS [o]
WHERE ([o].[OrderID] < 10500) AND (@_outer_CustomerID = [o].[CustomerID])",
                //
                @"@_outer_CustomerID='ANTON' (Size = 255)

SELECT TOP 3 [o].[OrderDate] AS [Date]
FROM [Orders] AS [o]
WHERE ([o].[OrderID] < 10500) AND (@_outer_CustomerID = [o].[CustomerID])",
                //
                @"@_outer_CustomerID='AROUT' (Size = 255)

SELECT TOP 3 [o].[OrderDate] AS [Date]
FROM [Orders] AS [o]
WHERE ([o].[OrderID] < 10500) AND (@_outer_CustomerID = [o].[CustomerID])");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_correlated_subquery_projection() : 
            AssertSql(
                @"@__p_0='3'

SELECT [t].[CustomerID]
FROM (
    SELECT TOP @__p_0 [c].*
    FROM [Customers] AS [c]
) AS [t]
ORDER BY [t].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Size = 255)

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = @_outer_CustomerID",
                //
                @"@_outer_CustomerID='ANATR' (Size = 255)

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = @_outer_CustomerID",
                //
                @"@_outer_CustomerID='ANTON' (Size = 255)

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = @_outer_CustomerID");



EntityFramework.Jet.FunctionalTests.QueryJetTest.IsNullOrEmpty_in_projection() : 
            AssertSql(
                @"SELECT [c].[CustomerID] AS [Id], IIf(
    [c].[Region] IS NULL OR ([c].[Region] = ''),
    True,
    False
) AS [Value]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_shadow_projection() : 
            AssertSql(
                @"SELECT [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[Title] = 'Sales Representative'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.GroupJoin_DefaultIfEmpty_Where() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Customers] AS [c]
LEFT JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [o].[OrderID] IS NOT NULL AND ([o].[CustomerID] = 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_constant_is_null() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested_negated() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE NOT EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A'))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Last() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactName] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_subquery_closure_via_query_cache() : 
            AssertSql(
                @"@__customerID_0='ALFKI' (Size = 255)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE ([o].[CustomerID] = @__customerID_0) AND ([o].[CustomerID] = [c].[CustomerID]))",
                //
                @"@__customerID_0='ANATR' (Size = 255)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE ([o].[CustomerID] = @__customerID_0) AND ([o].[CustomerID] = [c].[CustomerID]))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_math_exp() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
WHERE ([od].[OrderID] = 11077) AND (EXP([od].[Discount]) > 1E0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Skip_Take() : 
            AssertSql(
                @"@__p_1='10'
@__p_0='5'

SELECT TOP @__p_1+@__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactName]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_de_morgan_or_optimizated() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE ([p].[Discontinued] = False) AND ([p].[ProductID] >= 20)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition() : 
            AssertSql(
                @"SELECT [e1].[EmployeeID], [e1].[City], [e1].[Country], [e1].[FirstName], [e1].[ReportsTo], [e1].[Title]
FROM [Employees] AS [e1]
WHERE [e1].[FirstName] = (
    SELECT TOP 1 [e].[FirstName]
    FROM [Employees] AS [e]
    ORDER BY [e].[EmployeeID]
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_scalar_primitive_after_take() : 
            AssertSql(
                @"@__p_0='9'

SELECT TOP @__p_0 [e].[EmployeeID]
FROM [Employees] AS [e]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.FirstOrDefault_inside_subquery_gets_server_evaluated() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ([c].[CustomerID] = 'ALFKI') AND ((
    SELECT TOP 1 [o].[CustomerID]
    FROM [Orders] AS [o]
    WHERE ([o].[CustomerID] = 'ALFKI') AND ([c].[CustomerID] = [o].[CustomerID])
) = 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.IsNullOrWhiteSpace_in_predicate() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[Region] IS NULL OR (LTRIM(RTRIM([c].[Region])) = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_array_closure() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI')",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Query_expression_with_to_string_and_contains() : 
            AssertSql(
                @"SELECT [o].[CustomerID]
FROM [Orders] AS [o]
WHERE [o].[OrderDate] IS NOT NULL AND (Instr(Str([o].[EmployeeID]), '10') > 0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Take_simple_projection() : 
            AssertSql(
                @"@__p_0='10'

SELECT TOP @__p_0 [c].[City]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_subquery_on_bool() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE 'Chai' IN (
    SELECT [p2].[ProductName]
    FROM [Products] AS [p2]
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.GroupJoin_DefaultIfEmpty3() : 
            AssertSql(
                @"@__p_0='1'

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM (
    SELECT TOP @__p_0 [c].*
    FROM [Customers] AS [c]
    ORDER BY [c].[CustomerID]
) AS [t]
LEFT JOIN [Orders] AS [o] ON [t].[CustomerID] = [o].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_client_deep_inside_predicate_and_server_top_level() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <> 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Join_customers_orders_with_subquery_predicate_with_take() : 
            AssertSql(
                @"@__p_0='5'

SELECT [c].[ContactName], [t].[OrderID]
FROM [Customers] AS [c]
INNER JOIN (
    SELECT TOP @__p_0 [o2].*
    FROM [Orders] AS [o2]
    WHERE [o2].[OrderID] > 0
    ORDER BY [o2].[OrderID]
) AS [t] ON [c].[CustomerID] = [t].[CustomerID]
WHERE [t].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_collection_false() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] NOT IN ('ABCDE', 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_parameter_compared_to_binary_expression() : 
            AssertSql(
                @"@__prm_0='True'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE IIf(
    [p].[ProductID] > 50,
    True,
    False
) <> @__prm_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Last_when_no_order_by() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_anonymous_conditional_expression() : 
            AssertSql(
                @"SELECT [p].[ProductID], IIf(
    [p].[UnitsInStock] > 0,
    True,
    False
) AS [IsAvailable]
FROM [Products] AS [p]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_not_bool_member_compared_to_binary_expression() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] <> IIf(
    [p].[ProductID] > 50,
    True,
    False
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_orderby_join_select() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] <> 'ALFKI'
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition_entity_equality_no_elements_FirstOrDefault() : 
            AssertSql(
                @"SELECT [e1].[EmployeeID], [e1].[City], [e1].[Country], [e1].[FirstName], [e1].[ReportsTo], [e1].[Title]
FROM [Employees] AS [e1]
WHERE (
    SELECT TOP 1 [e2].[EmployeeID]
    FROM [Employees] AS [e2]
    WHERE [e2].[EmployeeID] = 42
) = 0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_math_cos() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
WHERE ([od].[OrderID] = 11077) AND (COS([od].[Discount]) > 0E0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested2() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (([c].[City] <> 'London') OR [c].[City] IS NULL) AND EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A'))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Count_with_predicate() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.GroupBy_anonymous_with_where() : 
            AssertSql(
                @"SELECT [c].[City], [c].[CustomerID]
FROM [Customers] AS [c]
WHERE [c].[Country] IN ('Argentina', 'Austria', 'Brazil', 'France', 'Germany', 'USA')
ORDER BY [c].[City]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_list_inline_closure_mix() : line_closure_mix() in C:\Develop\ForPlanning\EntityFrameworkCore.Jet\test\EFCore.Jet.FunctionalTests\QueryJetTest.cs:riga 6244
            AssertSql(
                @"@__id_0='ALFKI' (Size = 255)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', @__id_0)",
                //
                @"@__id_0='ANATR' (Size = 255)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', @__id_0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_null_is_not_null() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_Where_Count_with_predicate() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Orders] AS [o]
WHERE ([o].[OrderID] > 10) AND (([o].[CustomerID] <> 'ALFKI') OR [o].[CustomerID] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.IsNullOrEmpty_negated_in_projection() : 
            AssertSql(
                @"SELECT [c].[CustomerID] AS [Id], IIf(
    [c].[Region] IS NOT NULL AND ([c].[Region] <> ''),
    True,
    False
) AS [Value]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OfType_Select_OfType_Select() : 
            AssertSql(
                @"SELECT TOP 1 [o#Customer].[City]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
ORDER BY [o].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_Where_Subquery_Equality() : 
            AssertSql(
                @"@__p_0='1'

SELECT [t].[OrderID], [t].[CustomerID], [t].[EmployeeID], [t].[OrderDate]
FROM (
    SELECT TOP @__p_0 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
    FROM [Orders] AS [o]
) AS [t]
ORDER BY [t].[OrderID]",
                //
                @"SELECT [t1].[OrderID]
FROM (
    SELECT TOP 2 [od0].*
    FROM [Order Details] AS [od0]
    ORDER BY [od0].[OrderID]
) AS [t1]",
                //
                @"@_outer_CustomerID2='VINET' (Size = 255)

SELECT TOP 1 [c3].[Country]
FROM [Customers] AS [c3]
WHERE [c3].[CustomerID] = @_outer_CustomerID2
ORDER BY [c3].[CustomerID]",
                //
                @"@_outer_OrderID1='10248'

SELECT TOP 1 [c4].[Country]
FROM [Orders] AS [o20]
INNER JOIN [Customers] AS [c4] ON [o20].[CustomerID] = [c4].[CustomerID]
WHERE [o20].[OrderID] = @_outer_OrderID1
ORDER BY [o20].[OrderID], [c4].[CustomerID]",
                //
                @"@_outer_CustomerID2='VINET' (Size = 255)

SELECT TOP 1 [c3].[Country]
FROM [Customers] AS [c3]
WHERE [c3].[CustomerID] = @_outer_CustomerID2
ORDER BY [c3].[CustomerID]",
                //
                @"@_outer_OrderID1='10248'

SELECT TOP 1 [c4].[Country]
FROM [Orders] AS [o20]
INNER JOIN [Customers] AS [c4] ON [o20].[CustomerID] = [c4].[CustomerID]
WHERE [o20].[OrderID] = @_outer_OrderID1
ORDER BY [o20].[OrderID], [c4].[CustomerID]",
                //
                @"@_outer_CustomerID2='VINET' (Size = 255)

SELECT TOP 1 [c3].[Country]
FROM [Customers] AS [c3]
WHERE [c3].[CustomerID] = @_outer_CustomerID2
ORDER BY [c3].[CustomerID]",
                //
                @"@_outer_OrderID1='10248'

SELECT TOP 1 [c4].[Country]
FROM [Orders] AS [o20]
INNER JOIN [Customers] AS [c4] ON [o20].[CustomerID] = [c4].[CustomerID]
WHERE [o20].[OrderID] = @_outer_OrderID1
ORDER BY [o20].[OrderID], [c4].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition2_FirstOrDefault_with_anonymous() : 
            AssertSql(
                @"@__p_0='3'

SELECT [t].[EmployeeID], [t].[City], [t].[Country], [t].[FirstName], [t].[ReportsTo], [t].[Title]
FROM (
    SELECT TOP @__p_0 [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
    FROM [Employees] AS [e]
) AS [t]",
                //
                @"SELECT TOP 1 [e0].[EmployeeID], [e0].[City], [e0].[Country], [e0].[FirstName], [e0].[ReportsTo], [e0].[Title]
FROM [Employees] AS [e0]
ORDER BY [e0].[EmployeeID]",
                //
                @"SELECT TOP 1 [e0].[EmployeeID], [e0].[City], [e0].[Country], [e0].[FirstName], [e0].[ReportsTo], [e0].[Title]
FROM [Employees] AS [e0]
ORDER BY [e0].[EmployeeID]",
                //
                @"SELECT TOP 1 [e0].[EmployeeID], [e0].[City], [e0].[Country], [e0].[FirstName], [e0].[ReportsTo], [e0].[Title]
FROM [Employees] AS [e0]
ORDER BY [e0].[EmployeeID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_Where_Subquery_Deep_Single() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
WHERE [od].[OrderID] = 10344",
                //
                @"@_outer_OrderID='10344'

SELECT TOP 2 [o0].[CustomerID]
FROM [Orders] AS [o0]
WHERE @_outer_OrderID = [o0].[OrderID]",
                //
                @"@_outer_CustomerID1='WHITC' (Size = 255)

SELECT TOP 2 [c2].[City]
FROM [Customers] AS [c2]
WHERE @_outer_CustomerID1 = [c2].[CustomerID]",
                //
                @"@_outer_OrderID='10344'

SELECT TOP 2 [o0].[CustomerID]
FROM [Orders] AS [o0]
WHERE @_outer_OrderID = [o0].[OrderID]",
                //
                @"@_outer_CustomerID1='WHITC' (Size = 255)

SELECT TOP 2 [c2].[City]
FROM [Customers] AS [c2]
WHERE @_outer_CustomerID1 = [c2].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_ternary_boolean_condition_with_another_condition() : 
            AssertSql(
                @"@__productId_0='15'
@__flag_1='True'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE ([p].[ProductID] < @__productId_0) AND (((@__flag_1 = True) AND ([p].[UnitsInStock] >= 20)) OR ((@__flag_1 <> True) AND ([p].[UnitsInStock] < 20)))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_and_parameter_compared_to_binary_expression_nested() : 
            AssertSql(
                @"@__prm_0='True'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = IIf(
    IIf(
        [p].[ProductID] > 50,
        True,
        False
    ) <> @__prm_0,
    True,
    False
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_Last() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'
ORDER BY [c].[ContactName] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Contains_MethodCall() : 
            AssertSql(
                @"@__LocalMethod1_0='M' (Size = 4000)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (Instr([c].[ContactName], @__LocalMethod1_0) > 0) OR (@__LocalMethod1_0 = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_compare_with_parameter() : 
            AssertSql(
                @"@__customer_CustomerID_0='ALFKI' (Size = 4000)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] > @__customer_CustomerID_0",
                //
                @"@__customer_CustomerID_0='ALFKI' (Size = 4000)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] < @__customer_CustomerID_0",
                //
                @"@__customer_CustomerID_0='ALFKI' (Size = 4000)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <= @__customer_CustomerID_0",
                //
                @"@__customer_CustomerID_0='ALFKI' (Size = 4000)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <= @__customer_CustomerID_0",
                //
                @"@__customer_CustomerID_0='ALFKI' (Size = 4000)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] >= @__customer_CustomerID_0",
                //
                @"@__customer_CustomerID_0='ALFKI' (Size = 4000)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] >= @__customer_CustomerID_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Anonymous_complex_distinct_where() : 
            AssertSql(
                @"SELECT [t].[A]
FROM (
    SELECT DISTINCT [c].[CustomerID] + [c].[City] AS [A]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[A] = 'ALFKIBerlin'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_equals_constant() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Take_Distinct() : 
            AssertSql(
                @"@__p_0='5'

SELECT DISTINCT [t].*
FROM (
    SELECT TOP @__p_0 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
    FROM [Orders] AS [o]
    ORDER BY [o].[OrderID]
) AS [t]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_OrderBy_Count() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_ternary_boolean_condition_with_false_as_result_false() : 
            AssertSql(
                @"@__flag_0='False'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE (@__flag_0 = True) AND ([p].[UnitsInStock] >= 20)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Compare_multi_predicate() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] >= 'ALFKI' AND [c].[CustomerID] < 'CACTU'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[ContactTitle] = 'Owner' AND [c].[Country] <> 'USA'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.DTO_complex_distinct_result() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM (
    SELECT DISTINCT [c].[CustomerID] + [c].[City] AS [Property]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[Property] LIKE 'A' + '%' AND (LEFT([t].[Property], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_ternary_boolean_condition_with_false_as_result_true() : 
            AssertSql(
                @"@__flag_0='True'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE (@__flag_0 = True) AND ([p].[UnitsInStock] >= 20)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_compare_null() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] IS NULL AND ([c].[Country] = 'UK')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_Take_Count() : 
            AssertSql(
                @"@__p_0='5'

SELECT COUNT(*)
FROM (
    SELECT TOP @__p_0 [o].*
    FROM [Orders] AS [o]
    ORDER BY [o].[OrderID]
) AS [t]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_take_count() : 
            AssertSql(
                @"@__p_0='7'

SELECT COUNT(*)
FROM (
    SELECT TOP @__p_0 [c].*
    FROM [Customers] AS [c]
) AS [t]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_subquery_correlated_client_eval() : 
            AssertSql(
                @"@__p_0='5'

SELECT [t].[CustomerID], [t].[Address], [t].[City], [t].[CompanyName], [t].[ContactName], [t].[ContactTitle], [t].[Country], [t].[Fax], [t].[Phone], [t].[PostalCode], [t].[Region]
FROM (
    SELECT TOP @__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
    FROM [Customers] AS [c]
) AS [t]
ORDER BY [t].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Size = 255)

SELECT [c2].[CustomerID], [c2].[Address], [c2].[City], [c2].[CompanyName], [c2].[ContactName], [c2].[ContactTitle], [c2].[Country], [c2].[Fax], [c2].[Phone], [c2].[PostalCode], [c2].[Region]
FROM [Customers] AS [c2]
WHERE @_outer_CustomerID = [c2].[CustomerID]",
                //
                @"@_outer_CustomerID='ANATR' (Size = 255)

SELECT [c2].[CustomerID], [c2].[Address], [c2].[City], [c2].[CompanyName], [c2].[ContactName], [c2].[ContactTitle], [c2].[Country], [c2].[Fax], [c2].[Phone], [c2].[PostalCode], [c2].[Region]
FROM [Customers] AS [c2]
WHERE @_outer_CustomerID = [c2].[CustomerID]",
                //
                @"@_outer_CustomerID='ANTON' (Size = 255)

SELECT [c2].[CustomerID], [c2].[Address], [c2].[City], [c2].[CompanyName], [c2].[ContactName], [c2].[ContactTitle], [c2].[Country], [c2].[Fax], [c2].[Phone], [c2].[PostalCode], [c2].[Region]
FROM [Customers] AS [c2]
WHERE @_outer_CustomerID = [c2].[CustomerID]",
                //
                @"@_outer_CustomerID='AROUT' (Size = 255)

SELECT [c2].[CustomerID], [c2].[Address], [c2].[City], [c2].[CompanyName], [c2].[ContactName], [c2].[ContactTitle], [c2].[Country], [c2].[Fax], [c2].[Phone], [c2].[PostalCode], [c2].[Region]
FROM [Customers] AS [c2]
WHERE @_outer_CustomerID = [c2].[CustomerID]",
                //
                @"@_outer_CustomerID='BERGS' (Size = 255)

SELECT [c2].[CustomerID], [c2].[Address], [c2].[City], [c2].[CompanyName], [c2].[ContactName], [c2].[ContactTitle], [c2].[Country], [c2].[Fax], [c2].[Phone], [c2].[PostalCode], [c2].[Region]
FROM [Customers] AS [c2]
WHERE @_outer_CustomerID = [c2].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Entity_equality_local() : 
            AssertSql(
                @"@__local_0_CustomerID='ANATR' (Nullable = false) (Size = 255)

SELECT [c].[CustomerID]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = @__local_0_CustomerID");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Queryable_simple_anonymous_projection_subquery() : 
            AssertSql(
                @"@__p_0='91'

SELECT TOP @__p_0 [c].[City]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_primitive() : 
            AssertSql(
                @"@__p_0='9'

SELECT [t].[EmployeeID]
FROM (
    SELECT TOP @__p_0 [e].[EmployeeID]
    FROM [Employees] AS [e]
) AS [t]
WHERE [t].[EmployeeID] = 5");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_false() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = False");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_comparison_operator() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY IIf(
    [c].[Region] = 'ASK',
    True,
    False
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition_entity_equality_multiple_elements_FirstOrDefault() : 
            AssertSql(
                @"SELECT [e1].[EmployeeID], [e1].[City], [e1].[Country], [e1].[FirstName], [e1].[ReportsTo], [e1].[Title]
FROM [Employees] AS [e1]
WHERE (
    SELECT TOP 1 [e2].[EmployeeID]
    FROM [Employees] AS [e2]
    WHERE ([e2].[EmployeeID] <> [e1].[ReportsTo]) OR [e1].[ReportsTo] IS NULL
) = 0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_equals_using_object_overload_on_mismatched_types() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_collection_complex_predicate_and() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ALFKI', 'ABCDE') AND [c].[CustomerID] IN ('ABCDE', 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_shadow() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_equals_on_mismatched_types_nullable_long_nullable_int() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE False = True",
                //
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.SelectMany_mixed() : 
            AssertSql(
                @"@__p_0='2'

SELECT [t].[EmployeeID], [t].[City], [t].[Country], [t].[FirstName], [t].[ReportsTo], [t].[Title]
FROM (
    SELECT TOP @__p_0 [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
    FROM [Employees] AS [e]
    ORDER BY [e].[EmployeeID]
) AS [t]",
                //
                @"SELECT [t0].[CustomerID], [t0].[Address], [t0].[City], [t0].[CompanyName], [t0].[ContactName], [t0].[ContactTitle], [t0].[Country], [t0].[Fax], [t0].[Phone], [t0].[PostalCode], [t0].[Region]
FROM (
    SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
    FROM [Customers] AS [c]
    ORDER BY [c].[CustomerID]
) AS [t0]",
                //
                @"SELECT [t0].[CustomerID], [t0].[Address], [t0].[City], [t0].[CompanyName], [t0].[ContactName], [t0].[ContactTitle], [t0].[Country], [t0].[Fax], [t0].[Phone], [t0].[PostalCode], [t0].[Region]
FROM (
    SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
    FROM [Customers] AS [c]
    ORDER BY [c].[CustomerID]
) AS [t0]",
                //
                @"SELECT [t0].[CustomerID], [t0].[Address], [t0].[City], [t0].[CompanyName], [t0].[ContactName], [t0].[ContactTitle], [t0].[Country], [t0].[Fax], [t0].[Phone], [t0].[PostalCode], [t0].[Region]
FROM (
    SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
    FROM [Customers] AS [c]
    ORDER BY [c].[CustomerID]
) AS [t0]",
                //
                @"SELECT [t0].[CustomerID], [t0].[Address], [t0].[City], [t0].[CompanyName], [t0].[ContactName], [t0].[ContactTitle], [t0].[Country], [t0].[Fax], [t0].[Phone], [t0].[PostalCode], [t0].[Region]
FROM (
    SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
    FROM [Customers] AS [c]
    ORDER BY [c].[CustomerID]
) AS [t0]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_StartsWith_Literal() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[ContactName] LIKE 'M' + '%' AND (LEFT([c].[ContactName], LEN('M')) = 'M')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition_entity_equality_one_element_FirstOrDefault() : 
            AssertSql(
                @"SELECT [e1].[EmployeeID], [e1].[City], [e1].[Country], [e1].[FirstName], [e1].[ReportsTo], [e1].[Title]
FROM [Employees] AS [e1]
WHERE (
    SELECT TOP 1 [e2].[EmployeeID]
    FROM [Employees] AS [e2]
    WHERE [e2].[EmployeeID] = [e1].[ReportsTo]
) = 0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_false_shadow() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = False");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_math_tan() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
WHERE ([od].[OrderID] = 11077) AND (TAN([od].[Discount]) > 0E0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_array_inline() : line() in C:\Develop\ForPlanning\EntityFrameworkCore.Jet\test\EFCore.Jet.FunctionalTests\QueryJetTest.cs:riga 6214
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_conditional_operator_where_condition_null() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY IIf(
    False = True,
    'ZZ',
    [c].[City]
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Last_Predicate() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'
ORDER BY [c].[ContactName] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Entity_equality_local_inline() : line() in C:\Develop\ForPlanning\EntityFrameworkCore.Jet\test\EFCore.Jet.FunctionalTests\QueryJetTest.cs:riga 175
            AssertSql(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ANATR'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.GroupJoin_Where() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Environment_newline_is_funcletized() : line_is_funcletized() in C:\Develop\ForPlanning\EntityFrameworkCore.Jet\test\EFCore.Jet.FunctionalTests\QueryJetTest.cs:riga 6640
            AssertSql(
                @"@__NewLine_0='
' (Size = 4000)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (Instr([c].[CustomerID], @__NewLine_0) > 0) OR (@__NewLine_0 = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Compare_simple_one() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] > 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] < 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <= 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <= 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] >= 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] >= 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition_entity_equality_no_elements_SingleOrDefault() : 
            AssertSql(
                @"@__p_0='3'

SELECT [t].[EmployeeID], [t].[City], [t].[Country], [t].[FirstName], [t].[ReportsTo], [t].[Title]
FROM (
    SELECT TOP @__p_0 [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
    FROM [Employees] AS [e]
) AS [t]",
                //
                @"SELECT TOP 2 [e20].[EmployeeID]
FROM [Employees] AS [e20]
WHERE [e20].[EmployeeID] = 42",
                //
                @"SELECT TOP 2 [e20].[EmployeeID]
FROM [Employees] AS [e20]
WHERE [e20].[EmployeeID] = 42",
                //
                @"SELECT TOP 2 [e20].[EmployeeID]
FROM [Employees] AS [e20]
WHERE [e20].[EmployeeID] = 42");



EntityFramework.Jet.FunctionalTests.QueryJetTest.LastOrDefault_Predicate() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'
ORDER BY [c].[ContactName] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_complex_negated_expression_optimized() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE (([p].[Discontinued] = False) AND ([p].[ProductID] < 60)) AND ([p].[ProductID] > 30)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_list_closure() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Subquery_member_pushdown_does_not_change_original_subquery_model() : 
            AssertSql(
                @"@__p_0='3'

SELECT [t].[CustomerID], [t].[OrderID]
FROM (
    SELECT TOP @__p_0 [o].*
    FROM [Orders] AS [o]
    ORDER BY [o].[OrderID]
) AS [t]",
                //
                @"@_outer_CustomerID='VINET' (Size = 255)

SELECT TOP 2 [c0].[City]
FROM [Customers] AS [c0]
WHERE [c0].[CustomerID] = @_outer_CustomerID",
                //
                @"@_outer_CustomerID='TOMSP' (Size = 255)

SELECT TOP 2 [c0].[City]
FROM [Customers] AS [c0]
WHERE [c0].[CustomerID] = @_outer_CustomerID",
                //
                @"@_outer_CustomerID='HANAR' (Size = 255)

SELECT TOP 2 [c0].[City]
FROM [Customers] AS [c0]
WHERE [c0].[CustomerID] = @_outer_CustomerID",
                //
                @"@_outer_CustomerID1='TOMSP' (Size = 255)

SELECT TOP 2 [c2].[City]
FROM [Customers] AS [c2]
WHERE [c2].[CustomerID] = @_outer_CustomerID1",
                //
                @"@_outer_CustomerID1='VINET' (Size = 255)

SELECT TOP 2 [c2].[City]
FROM [Customers] AS [c2]
WHERE [c2].[CustomerID] = @_outer_CustomerID1",
                //
                @"@_outer_CustomerID1='HANAR' (Size = 255)

SELECT TOP 2 [c2].[City]
FROM [Customers] AS [c2]
WHERE [c2].[CustomerID] = @_outer_CustomerID1");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_Where_Count_with_predicate_client_eval_mixed() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE ([o].[CustomerID] <> 'ALFKI') OR [o].[CustomerID] IS NULL");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_method_call_closure_via_query_cache() : 
            AssertSql(
                @"@__GetCity_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__GetCity_0",
                //
                @"@__GetCity_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__GetCity_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_StartsWith_Column() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ([c].[ContactName] LIKE [c].[ContactName] + '%' AND (LEFT([c].[ContactName], LEN([c].[ContactName])) = [c].[ContactName])) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_alias_generation(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
ORDER BY [o].[OrderID]",
                //
                @"SELECT [o#OrderDetails].[OrderID], [o#OrderDetails].[ProductID], [o#OrderDetails].[Discount], [o#OrderDetails].[Quantity], [o#OrderDetails].[UnitPrice]
FROM [Order Details] AS [o#OrderDetails]
INNER JOIN (
    SELECT [o0].[OrderID]
    FROM [Orders] AS [o0]
) AS [t] ON [o#OrderDetails].[OrderID] = [t].[OrderID]
ORDER BY [t].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_client_and_server_top_level() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <> 'AROUT'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_shadow() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[Title] = 'Sales Representative'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_project_filter() : 
            AssertSql(
                @"SELECT [c].[CompanyName]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_StartsWith_MethodCall() : 
            AssertSql(
                @"@__LocalMethod1_0='M' (Nullable = false) (Size = 1)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ([c].[ContactName] LIKE @__LocalMethod1_0 + '%' AND (LEFT([c].[ContactName], LEN(@__LocalMethod1_0)) = @__LocalMethod1_0)) OR (@__LocalMethod1_0 = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.First_inside_subquery_gets_client_evaluated() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 1 [o0].[CustomerID]
FROM [Orders] AS [o0]
WHERE ([o0].[CustomerID] = 'ALFKI') AND (@_outer_CustomerID = [o0].[CustomerID])");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_Count_with_predicate() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_equals_method_string() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_alias_generation(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
ORDER BY [o].[OrderID]",
                //
                @"SELECT [o#OrderDetails].[OrderID], [o#OrderDetails].[ProductID], [o#OrderDetails].[Discount], [o#OrderDetails].[Quantity], [o#OrderDetails].[UnitPrice]
FROM [Order Details] AS [o#OrderDetails]
INNER JOIN (
    SELECT [o0].[OrderID]
    FROM [Orders] AS [o0]
) AS [t] ON [o#OrderDetails].[OrderID] = [t].[OrderID]
ORDER BY [t].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.GroupJoin_Where_OrderBy() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE ([o].[CustomerID] = 'ALFKI') OR ([c].[CustomerID] = 'ANATR')
ORDER BY [c].[City]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_Subquery_Single() : 
            AssertSql(
                @"@__p_0='2'

SELECT TOP @__p_0 [od].[OrderID]
FROM [Order Details] AS [od]
ORDER BY [od].[ProductID], [od].[OrderID]",
                //
                @"@_outer_OrderID='10285'

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_OrderID = [o].[OrderID]
ORDER BY [o].[OrderID]",
                //
                @"@_outer_OrderID='10294'

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_OrderID = [o].[OrderID]
ORDER BY [o].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_expression_int_to_string() : 
            AssertSql(
                @"SELECT Str([o].[OrderID]) AS [ShipName]
FROM [Orders] AS [o]
WHERE [o].[OrderDate] IS NOT NULL");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_closure() : 
            AssertSql(
                @"@__city_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_project_filter2() : 
            AssertSql(
                @"SELECT [c].[City]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_conditional_operator() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY IIf(
    [c].[Region] IS NULL,
    'ZZ',
    [c].[Region]
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_collection_complex_predicate_not_matching_ins2() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI') AND [c].[CustomerID] NOT IN ('ALFKI', 'ABCDE')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Contains_Column() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (Instr([c].[ContactName], [c].[ContactName]) > 0) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Anonymous_member_distinct_where() : 
            AssertSql(
                @"SELECT [t].[CustomerID]
FROM (
    SELECT DISTINCT [c].[CustomerID]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Contains_Identity() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (Instr([c].[ContactName], [c].[ContactName]) > 0) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_reversed() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE 'London' = [c].[City]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_concat_with_navigation2() : 
            AssertSql(
                @"SELECT ([o#Customer].[City] + ' ') + [o#Customer].[City]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_Where_Count() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_EndsWith_Literal() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE RIGHT([c].[ContactName], LEN('b')) = 'b'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_alias_generation(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[ProductID], [o].[Discount], [o].[Quantity], [o].[UnitPrice], [o#Order].[OrderID], [o#Order].[CustomerID], [o#Order].[EmployeeID], [o#Order].[OrderDate]
FROM [Order Details] AS [o]
INNER JOIN [Orders] AS [o#Order] ON [o].[OrderID] = [o#Order].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_static_field_access_closure_via_query_cache() : 
            AssertSql(
                @"@__StaticFieldValue_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__StaticFieldValue_0",
                //
                @"@__StaticFieldValue_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__StaticFieldValue_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested_negated3() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE NOT EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A')) AND (([c].[City] <> 'London') OR [c].[City] IS NULL)");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_on_join_clause_with_order_by_and_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[City], [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT DISTINCT [c0].[CustomerID], [c0].[City]
    FROM [Customers] AS [c0]
    INNER JOIN [Orders] AS [o0] ON [c0].[CustomerID] = [o0].[CustomerID]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[City], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_on_join_clause_with_order_by_and_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[City], [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT DISTINCT [c0].[CustomerID], [c0].[City]
    FROM [Customers] AS [c0]
    INNER JOIN [Orders] AS [o0] ON [c0].[CustomerID] = [o0].[CustomerID]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[City], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_dependent_already_tracked_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_dependent_already_tracked_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A'))");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_kiwi() : 
            AssertSql(
                @"SELECT [k].[Species], [k].[CountryId], [k].[Discriminator], [k].[Name], [k].[EagleId], [k].[IsFlightless], [k].[FoundOn]
FROM [Animal] AS [k]
WHERE ([k].[Discriminator] = 'Kiwi') AND ([k].[CountryId] = 1)");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_bird_first() : 
            AssertSql(
                @"SELECT TOP 1 [b].[Species], [b].[CountryId], [b].[Discriminator], [b].[Name], [b].[EagleId], [b].[IsFlightless], [b].[Group], [b].[FoundOn]
FROM [Animal] AS [b]
WHERE [b].[Discriminator] IN ('Kiwi', 'Eagle') AND ([b].[CountryId] = 1)
ORDER BY [b].[Species]");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_is_kiwi_in_projection() : 
            AssertSql(
                @"SELECT IIf(
    [a].[Discriminator] = 'Kiwi',
    True,
    False
)
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle') AND ([a].[CountryId] = 1)");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_bird_with_projection() : 
            AssertSql(
                @"SELECT [b].[EagleId]
FROM [Animal] AS [b]
WHERE [b].[Discriminator] IN ('Kiwi', 'Eagle') AND ([b].[CountryId] = 1)");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_is_kiwi() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE ([a].[Discriminator] IN ('Kiwi', 'Eagle') AND ([a].[CountryId] = 1)) AND ([a].[Discriminator] = 'Kiwi')");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_bird_predicate() : 
            AssertSql(
                @"SELECT [b].[Species], [b].[CountryId], [b].[Discriminator], [b].[Name], [b].[EagleId], [b].[IsFlightless], [b].[Group], [b].[FoundOn]
FROM [Animal] AS [b]
WHERE ([b].[Discriminator] IN ('Kiwi', 'Eagle') AND ([b].[CountryId] = 1)) AND ([b].[CountryId] = 1)
ORDER BY [b].[Species]");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_animal() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle') AND ([a].[CountryId] = 1)
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_bird() : 
            AssertSql(
                @"SELECT [b].[Species], [b].[CountryId], [b].[Discriminator], [b].[Name], [b].[EagleId], [b].[IsFlightless], [b].[Group], [b].[FoundOn]
FROM [Animal] AS [b]
WHERE [b].[Discriminator] IN ('Kiwi', 'Eagle') AND ([b].[CountryId] = 1)
ORDER BY [b].[Species]");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_is_kiwi_with_other_predicate() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE ([a].[Discriminator] IN ('Kiwi', 'Eagle') AND ([a].[CountryId] = 1)) AND (([a].[Discriminator] = 'Kiwi') AND ([a].[CountryId] = 1))");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_list_inline() : line() in C:\Develop\ForPlanning\EntityFrameworkCore.Jet\test\EFCore.Jet.FunctionalTests\QueryJetTest.cs:riga 6234
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.IsNullOrEmpty_in_predicate() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[Region] IS NULL OR ([c].[Region] = '')");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_dependent_already_tracked(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_dependent_already_tracked(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_on_join_clause_with_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT DISTINCT [c0].[CustomerID]
    FROM [Customers] AS [c0]
    INNER JOIN [Orders] AS [o0] ON [c0].[CustomerID] = [o0].[CustomerID]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_on_join_clause_with_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT DISTINCT [c0].[CustomerID]
    FROM [Customers] AS [c0]
    INNER JOIN [Orders] AS [o0] ON [c0].[CustomerID] = [o0].[CustomerID]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_closure_constant() : 
            AssertSql(
                @"@__predicate_0='True'

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE @__predicate_0 = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Take_simple() : 
            AssertSql(
                @"@__p_0='10'

SELECT TOP @__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.FiltersJetTest.Compiled_query() : 
            AssertSql(
                @"@__customerID='BERGS' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = @__customerID",
                //
                @"@__customerID='BLAUS' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = @__customerID");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_then_include_collection(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID], [c#Orders].[OrderID]",
                //
                @"SELECT [c#Orders#OrderDetails].[OrderID], [c#Orders#OrderDetails].[ProductID], [c#Orders#OrderDetails].[Discount], [c#Orders#OrderDetails].[Quantity], [c#Orders#OrderDetails].[UnitPrice]
FROM [Order Details] AS [c#Orders#OrderDetails]
INNER JOIN (
    SELECT DISTINCT [c#Orders0].[OrderID], [t0].[CustomerID]
    FROM [Orders] AS [c#Orders0]
    INNER JOIN (
        SELECT [c1].[CustomerID]
        FROM [Customers] AS [c1]
    ) AS [t0] ON [c#Orders0].[CustomerID] = [t0].[CustomerID]
) AS [t1] ON [c#Orders#OrderDetails].[OrderID] = [t1].[OrderID]
ORDER BY [t1].[CustomerID], [t1].[OrderID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_order_by_non_key_with_first_or_default(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CompanyName] DESC, [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID], [c0].[CompanyName]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CompanyName] DESC, [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CompanyName] DESC, [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_order_by_non_key_with_first_or_default(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CompanyName] DESC, [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID], [c0].[CompanyName]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CompanyName] DESC, [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CompanyName] DESC, [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_with_filter_reordered(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_kiwi_where_north_on_derived_property() : 
            AssertSql(
                @"SELECT [x].[Species], [x].[CountryId], [x].[Discriminator], [x].[Name], [x].[EagleId], [x].[IsFlightless], [x].[FoundOn]
FROM [Animal] AS [x]
WHERE ([x].[Discriminator] = 'Kiwi') AND ([x].[FoundOn] = 0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_negated_twice() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = True");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_animal() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_query_when_shared_column() : 
            AssertSql(
                @"SELECT TOP 2 [d].[Id], [d].[Discriminator], [d].[CaffeineGrams], [d].[CokeCO2], [d].[SugarGrams]
FROM [Drink] AS [d]
WHERE [d].[Discriminator] = 'Coke'",
                //
                @"SELECT TOP 2 [d].[Id], [d].[Discriminator], [d].[LiltCO2], [d].[SugarGrams]
FROM [Drink] AS [d]
WHERE [d].[Discriminator] = 'Lilt'",
                //
                @"SELECT TOP 2 [d].[Id], [d].[Discriminator], [d].[CaffeineGrams], [d].[HasMilk]
FROM [Drink] AS [d]
WHERE [d].[Discriminator] = 'Tea'");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_kiwi_where_south_on_derived_property() : 
            AssertSql(
                @"SELECT [x].[Species], [x].[CountryId], [x].[Discriminator], [x].[Name], [x].[EagleId], [x].[IsFlightless], [x].[FoundOn]
FROM [Animal] AS [x]
WHERE ([x].[Discriminator] = 'Kiwi') AND ([x].[FoundOn] = 1)");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_is_kiwi_with_other_predicate() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle') AND (([a].[Discriminator] = 'Kiwi') AND ([a].[CountryId] = 1))");



EntityFramework.Jet.FunctionalTests.FiltersJetTest.Include_query_opt_out() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_bird_predicate() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle') AND ([a].[CountryId] = 1)
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_is_kiwi_in_projection() : 
            AssertSql(
                @"SELECT IIf(
    [a].[Discriminator] = 'Kiwi',
    True,
    False
)
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle')");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Where_subquery_on_navigation_client_eval() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [o4].[OrderID]
FROM [Orders] AS [o4]",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT [o2].[OrderID]
FROM [Orders] AS [o2]
WHERE @_outer_CustomerID = [o2].[CustomerID]",
                //
                @"SELECT [o4].[OrderID]
FROM [Orders] AS [o4]",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT [o2].[OrderID]
FROM [Orders] AS [o2]
WHERE @_outer_CustomerID = [o2].[CustomerID]",
                //
                @"SELECT [o4].[OrderID]
FROM [Orders] AS [o4]",
                //
                @"@_outer_CustomerID='ANTON' (Nullable = false) (Size = 5)

SELECT [o2].[OrderID]
FROM [Orders] AS [o2]
WHERE @_outer_CustomerID = [o2].[CustomerID]",
                //
                @"SELECT [o4].[OrderID]
FROM [Orders] AS [o4]",
                //
                @"@_outer_CustomerID='AROUT' (Nullable = false) (Size = 5)

SELECT [o2].[OrderID]
FROM [Orders] AS [o2]
WHERE @_outer_CustomerID = [o2].[CustomerID]");

Output truncated.

EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_is_kiwi() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle') AND ([a].[Discriminator] = 'Kiwi')");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_bird_first() : 
            AssertSql(
                @"SELECT TOP 1 [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Discriminator_used_when_projection_over_derived_type2() : 
            AssertSql(
                @"SELECT [b].[IsFlightless], [b].[Discriminator]
FROM [Animal] AS [b]
WHERE [b].[Discriminator] IN ('Kiwi', 'Eagle')");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Collection_select_nav_prop_first_or_default_then_nav_prop() : 
            AssertSql(
                @"SELECT [e].[CustomerID]
FROM [Customers] AS [e]
WHERE [e].[CustomerID] LIKE 'A' + '%' AND (LEFT([e].[CustomerID], LEN('A')) = 'A')
ORDER BY [e].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 1 [e#Customer].[CustomerID], [e#Customer].[Address], [e#Customer].[City], [e#Customer].[CompanyName], [e#Customer].[ContactName], [e#Customer].[ContactTitle], [e#Customer].[Country], [e#Customer].[Fax], [e#Customer].[Phone], [e#Customer].[PostalCode], [e#Customer].[Region]
FROM [Orders] AS [e0]
LEFT JOIN [Customers] AS [e#Customer] ON [e0].[CustomerID] = [e#Customer].[CustomerID]
WHERE [e0].[OrderID] IN (10643, 10692, 10702, 10835, 10952, 11011) AND (@_outer_CustomerID = [e0].[CustomerID])",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT TOP 1 [e#Customer].[CustomerID], [e#Customer].[Address], [e#Customer].[City], [e#Customer].[CompanyName], [e#Customer].[ContactName], [e#Customer].[ContactTitle], [e#Customer].[Country], [e#Customer].[Fax], [e#Customer].[Phone], [e#Customer].[PostalCode], [e#Customer].[Region]
FROM [Orders] AS [e0]
LEFT JOIN [Customers] AS [e#Customer] ON [e0].[CustomerID] = [e#Customer].[CustomerID]
WHERE [e0].[OrderID] IN (10643, 10692, 10702, 10835, 10952, 11011) AND (@_outer_CustomerID = [e0].[CustomerID])",
                //
                @"@_outer_CustomerID='ANTON' (Nullable = false) (Size = 5)

SELECT TOP 1 [e#Customer].[CustomerID], [e#Customer].[Address], [e#Customer].[City], [e#Customer].[CompanyName], [e#Customer].[ContactName], [e#Customer].[ContactTitle], [e#Customer].[Country], [e#Customer].[Fax], [e#Customer].[Phone], [e#Customer].[PostalCode], [e#Customer].[Region]
FROM [Orders] AS [e0]
LEFT JOIN [Customers] AS [e#Customer] ON [e0].[CustomerID] = [e#Customer].[CustomerID]
WHERE [e0].[OrderID] IN (10643, 10692, 10702, 10835, 10952, 11011) AND (@_outer_CustomerID = [e0].[CustomerID])",
                //
                @"@_outer_CustomerID='AROUT' (Nullable = false) (Size = 5)

SELECT TOP 1 [e#Customer].[CustomerID], [e#Customer].[Address], [e#Customer].[City], [e#Customer].[CompanyName], [e#Customer].[ContactName], [e#Customer].[ContactTitle], [e#Customer].[Country], [e#Customer].[Fax], [e#Customer].[Phone], [e#Customer].[PostalCode], [e#Customer].[Region]
FROM [Orders] AS [e0]
LEFT JOIN [Customers] AS [e#Customer] ON [e0].[CustomerID] = [e#Customer].[CustomerID]
WHERE [e0].[OrderID] IN (10643, 10692, 10702, 10835, 10952, 11011) AND (@_outer_CustomerID = [e0].[CustomerID])");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Navigation_fk_based_inside_contains() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] IN ('ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Collection_where_nav_prop_all() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE NOT EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE ([c].[CustomerID] = [o].[CustomerID]) AND (([o].[CustomerID] <> 'ALFKI') OR [o].[CustomerID] IS NULL))");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.GroupBy_on_nav_prop() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[City]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
ORDER BY [o#Customer].[City]");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Select_correlated_filtered_collection_works_with_caching() : 
            AssertSql(
                @"SELECT [t].[GearNickName]
FROM [CogTag] AS [t]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_shadow_subquery_FirstOrDefault() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[Title] = (
    SELECT TOP 1 [e2].[Title]
    FROM [Employees] AS [e2]
    ORDER BY [e2].[Title]
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Join_Where_Count() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_false() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.GroupJoin_with_nav_projected_in_subquery_when_client_eval() : 
            AssertSql(
                @"SELECT [od0].[OrderID], [od0].[ProductID], [od0].[Discount], [od0].[Quantity], [od0].[UnitPrice], [od#Product0].[ProductID], [od#Product0].[Discontinued], [od#Product0].[ProductName], [od#Product0].[UnitPrice], [od#Product0].[UnitsInStock]
FROM [Order Details] AS [od0]
INNER JOIN [Products] AS [od#Product0] ON [od0].[ProductID] = [od#Product0].[ProductID]",
                //
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [o#Customer0].[CustomerID], [o#Customer0].[Address], [o#Customer0].[City], [o#Customer0].[CompanyName], [o#Customer0].[ContactName], [o#Customer0].[ContactTitle], [o#Customer0].[Country], [o#Customer0].[Fax], [o#Customer0].[Phone], [o#Customer0].[PostalCode], [o#Customer0].[Region]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Select_ternary_operation_with_has_value_not_null() : 
            AssertSql(
                @"SELECT [w].[Id], IIf(
    [w].[AmmunitionType] IS NOT NULL AND ([w].[AmmunitionType] = 1),
    'Yes',
    'No'
) AS [IsCartidge]
FROM [Weapon] AS [w]
WHERE [w].[AmmunitionType] IS NOT NULL AND ([w].[AmmunitionType] = 1)");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_and_collection(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
ORDER BY [o].[OrderID]",
                //
                @"SELECT [o#OrderDetails].[OrderID], [o#OrderDetails].[ProductID], [o#OrderDetails].[Discount], [o#OrderDetails].[Quantity], [o#OrderDetails].[UnitPrice]
FROM [Order Details] AS [o#OrderDetails]
INNER JOIN (
    SELECT DISTINCT [o0].[OrderID]
    FROM [Orders] AS [o0]
    LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]
) AS [t] ON [o#OrderDetails].[OrderID] = [t].[OrderID]
ORDER BY [t].[OrderID]");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Select_inverted_boolean() : 
            AssertSql(
                @"SELECT [w].[Id], IIf(
    [w].[IsAutomatic] = False,
    True,
    False
) AS [Manual]
FROM [Weapon] AS [w]
WHERE [w].[IsAutomatic] = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.DTO_member_distinct_result() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM (
    SELECT DISTINCT [c].[CustomerID] AS [Property]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[Property] LIKE 'A' + '%' AND (LEFT([t].[Property], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Include_on_GroupJoin_SelectMany_DefaultIfEmpty_with_complex_projection_result() : 
            AssertSql(
                @"SELECT [g].[Nickname], [g].[SquadId], [g].[AssignedCityName], [g].[CityOrBirthName], [g].[Discriminator], [g].[FullName], [g].[HasSoulPatch], [g].[LeaderNickname], [g].[LeaderSquadId], [g].[Rank], [t].[Nickname], [t].[SquadId], [t].[AssignedCityName], [t].[CityOrBirthName], [t].[Discriminator], [t].[FullName], [t].[HasSoulPatch], [t].[LeaderNickname], [t].[LeaderSquadId], [t].[Rank]
FROM [Gear] AS [g]
LEFT JOIN (
    SELECT [g2].*
    FROM [Gear] AS [g2]
    WHERE [g2].[Discriminator] IN ('Officer', 'Gear')
) AS [t] ON [g].[LeaderNickname] = [t].[Nickname]
WHERE [g].[Discriminator] IN ('Officer', 'Gear')
ORDER BY [g].[FullName], [t].[FullName]");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Sum_with_optional_navigation_is_translated_to_sql() : 
            AssertSql(
                @"SELECT SUM([g].[SquadId])
FROM [Gear] AS [g]
LEFT JOIN [CogTag] AS [g#Tag] ON ([g].[Nickname] = [g#Tag].[GearNickName]) AND ([g].[SquadId] = [g#Tag].[GearSquadId])
WHERE [g].[Discriminator] IN ('Officer', 'Gear') AND (([g#Tag].[Note] <> 'Foo') OR [g#Tag].[Note] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Navigation() : 
            AssertSql(
                @"SELECT [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_and_collection(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
ORDER BY [o].[OrderID]",
                //
                @"SELECT [o#OrderDetails].[OrderID], [o#OrderDetails].[ProductID], [o#OrderDetails].[Discount], [o#OrderDetails].[Quantity], [o#OrderDetails].[UnitPrice]
FROM [Order Details] AS [o#OrderDetails]
INNER JOIN (
    SELECT DISTINCT [o0].[OrderID]
    FROM [Orders] AS [o0]
    LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]
) AS [t] ON [o#OrderDetails].[OrderID] = [t].[OrderID]
ORDER BY [t].[OrderID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_when_groupby(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[City], [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID], [c0].[City]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[City], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Join_with_nav_in_orderby_in_subquery_when_client_eval() : 
            AssertSql(
                @"SELECT [od0].[OrderID], [od0].[ProductID], [od0].[Discount], [od0].[Quantity], [od0].[UnitPrice], [od#Product0].[ProductID], [od#Product0].[Discontinued], [od#Product0].[ProductName], [od#Product0].[UnitPrice], [od#Product0].[UnitsInStock]
FROM [Order Details] AS [od0]
INNER JOIN [Products] AS [od#Product0] ON [od0].[ProductID] = [od#Product0].[ProductID]",
                //
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [o#Customer0].[CustomerID], [o#Customer0].[Address], [o#Customer0].[City], [o#Customer0].[CompanyName], [o#Customer0].[ContactName], [o#Customer0].[ContactTitle], [o#Customer0].[Country], [o#Customer0].[Fax], [o#Customer0].[Phone], [o#Customer0].[PostalCode], [o#Customer0].[Region]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_last_no_orderby(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID] DESC",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CustomerID] DESC
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID] DESC");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Where_Navigation() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o#Customer].[City] = 'Seattle'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_EndsWith_Identity() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (RIGHT([c].[ContactName], LEN([c].[ContactName])) = [c].[ContactName]) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_de_morgan_and_optimizated() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE ([p].[Discontinued] = False) OR ([p].[ProductID] >= 20)");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Select_comparison_with_null() : 
            AssertSql(
                @"@__ammunitionType_0='Cartridge'
@__ammunitionType_1='Cartridge'

SELECT [w].[Id], IIf(
    [w].[AmmunitionType] = @__ammunitionType_1,
    True,
    False
) AS [Cartidge]
FROM [Weapon] AS [w]
WHERE [w].[AmmunitionType] = @__ammunitionType_0",
                //
                @"SELECT [w].[Id], IIf(
    [w].[AmmunitionType] IS NULL,
    True,
    False
) AS [Cartidge]
FROM [Weapon] AS [w]
WHERE [w].[AmmunitionType] IS NULL");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Local_array() : 
            AssertSql(
                @"@__get_Item_0='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = @__get_Item_0");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Entity_equality_empty() : 
            AssertSql(
                @"SELECT [g].[Nickname], [g].[SquadId], [g].[AssignedCityName], [g].[CityOrBirthName], [g].[Discriminator], [g].[FullName], [g].[HasSoulPatch], [g].[LeaderNickname], [g].[LeaderSquadId], [g].[Rank]
FROM [Gear] AS [g]
WHERE [g].[Discriminator] IN ('Officer', 'Gear') AND ([g].[Nickname] IS NULL AND ([g].[SquadId] = 0))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Join_Customers_Orders_Skip_Take() : 
            AssertSql(
                @"@__p_0='10'
@__p_1='5'

SELECT TOP @__p_1+@__p_0 [c].[ContactName], [o].[OrderID]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
ORDER BY [o].[OrderID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_principal_already_tracked_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_collection_FirstOrDefault_project_entity() : 
            AssertSql(
                @"@__p_0='2'

SELECT TOP @__p_0 [c].[CustomerID]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Singleton_Navigation_With_Member_Access() : 
            AssertSql(
                @"SELECT [o#Customer].[City] AS [B]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE ([o#Customer].[City] = 'Seattle') AND (([o#Customer].[Phone] <> '555 555 5555') OR [o#Customer].[Phone] IS NULL)");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_dependent_already_tracked(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_dependent_already_tracked(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_EndsWith_MethodCall() : 
            AssertSql(
                @"@__LocalMethod2_0='m' (Nullable = false) (Size = 1)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (RIGHT([c].[ContactName], LEN(@__LocalMethod2_0)) = @__LocalMethod2_0) OR (@__LocalMethod2_0 = '')");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.GroupJoin_with_nav_in_predicate_in_subquery_when_client_eval() : 
            AssertSql(
                @"SELECT [od0].[OrderID], [od0].[ProductID], [od0].[Discount], [od0].[Quantity], [od0].[UnitPrice], [od#Product0].[ProductID], [od#Product0].[Discontinued], [od#Product0].[ProductName], [od#Product0].[UnitPrice], [od#Product0].[UnitsInStock]
FROM [Order Details] AS [od0]
INNER JOIN [Products] AS [od#Product0] ON [od0].[ProductID] = [od#Product0].[ProductID]",
                //
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [o#Customer0].[CustomerID], [o#Customer0].[Address], [o#Customer0].[City], [o#Customer0].[CompanyName], [o#Customer0].[ContactName], [o#Customer0].[ContactTitle], [o#Customer0].[Country], [o#Customer0].[Fax], [o#Customer0].[Phone], [o#Customer0].[PostalCode], [o#Customer0].[Region]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Project_single_entity_value_subquery_works() : 
            AssertSql(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]
ORDER BY [o].[OrderID]",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]
ORDER BY [o].[OrderID]",
                //
                @"@_outer_CustomerID='ANTON' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]
ORDER BY [o].[OrderID]",
                //
                @"@_outer_CustomerID='AROUT' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]
ORDER BY [o].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_closure_via_query_cache() : 
            AssertSql(
                @"@__city_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_0",
                //
                @"@__city_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_0");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.GroupJoin_with_nav_in_orderby_in_subquery_when_client_eval() : 
            AssertSql(
                @"SELECT [od0].[OrderID], [od0].[ProductID], [od0].[Discount], [od0].[Quantity], [od0].[UnitPrice], [od#Product0].[ProductID], [od#Product0].[Discontinued], [od#Product0].[ProductName], [od#Product0].[UnitPrice], [od#Product0].[UnitsInStock]
FROM [Order Details] AS [od0]
INNER JOIN [Products] AS [od#Product0] ON [od0].[ProductID] = [od#Product0].[ProductID]",
                //
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [o#Customer0].[CustomerID], [o#Customer0].[Address], [o#Customer0].[City], [o#Customer0].[CompanyName], [o#Customer0].[ContactName], [o#Customer0].[ContactTitle], [o#Customer0].[Country], [o#Customer0].[Fax], [o#Customer0].[Phone], [o#Customer0].[PostalCode], [o#Customer0].[Region]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Take_Select_Navigation() : 
            AssertSql(
                @"@__p_0='2'

SELECT TOP @__p_0 [c].[CustomerID]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_expression_invoke() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Anonymous_member_distinct_result() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM (
    SELECT DISTINCT [c].[CustomerID]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[CustomerID] LIKE 'A' + '%' AND (LEFT([t].[CustomerID], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Join_Customers_Orders_Projection_With_String_Concat_Skip_Take() : 
            AssertSql(
                @"@__p_0='10'
@__p_1='5'

SELECT TOP @__p_1+@__p_0 ([c].[ContactName] + ' ') + [c].[ContactTitle] AS [Contact], [o].[OrderID]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
ORDER BY [o].[OrderID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_compared_to_binary_expression() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = IIf(
    [p].[ProductID] > 50,
    True,
    False
)");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Join_with_nav_in_predicate_in_subquery_when_client_eval() : 
            AssertSql(
                @"SELECT [od0].[OrderID], [od0].[ProductID], [od0].[Discount], [od0].[Quantity], [od0].[UnitPrice], [od#Product0].[ProductID], [od#Product0].[Discontinued], [od#Product0].[ProductName], [od#Product0].[UnitPrice], [od#Product0].[UnitsInStock]
FROM [Order Details] AS [od0]
INNER JOIN [Products] AS [od#Product0] ON [od0].[ProductID] = [od#Product0].[ProductID]",
                //
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [o#Customer0].[CustomerID], [o#Customer0].[Address], [o#Customer0].[City], [o#Customer0].[CompanyName], [o#Customer0].[ContactName], [o#Customer0].[ContactTitle], [o#Customer0].[Country], [o#Customer0].[Fax], [o#Customer0].[Phone], [o#Customer0].[PostalCode], [o#Customer0].[Region]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Null_conditional_simple() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Navigation_inside_contains() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o#Customer].[City] IN ('Novigrad', 'Seattle')");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_collection_FirstOrDefault_project_anonymous_type() : 
            AssertSql(
                @"@__p_0='2'

SELECT TOP @__p_0 [c].[CustomerID]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[CustomerID], [o].[OrderID]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[CustomerID], [o].[OrderID]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Where_Navigation_Multiple_Access() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE ([o#Customer].[City] = 'Seattle') AND (([o#Customer].[Phone] <> '555 555 5555') OR [o#Customer].[Phone] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_subquery_and_local_array_closure() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Customers] AS [c1]
    WHERE [c1].[City] IN ('London', 'Buenos Aires') AND ([c1].[CustomerID] = [c].[CustomerID]))",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Customers] AS [c1]
    WHERE [c1].[City] IN ('London') AND ([c1].[CustomerID] = [c].[CustomerID]))");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_with_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_with_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_with_skip(Boolean useString) : 
            AssertSql(
                @"@__p_0='80'

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactName], [c].[CustomerID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_with_skip(Boolean useString) : 
            AssertSql(
                @"@__p_0='80'

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactName], [c].[CustomerID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_equals_on_mismatched_types_nullable_int_long() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE False = True",
                //
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Collection_select_nav_prop_all_client() : 
            AssertSql(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='ANTON' (Nullable = false) (Size = 5)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='AROUT' (Nullable = false) (Size = 5)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='BERGS' (Nullable = false) (Size = 5)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='BLAUS' (Nullable = false) (Size = 5)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='BLONP' (Nullable = false) (Size = 5)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='BOLID' (Nullable = false) (Size = 5)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]");

Output truncated.

EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Where_Navigation_Null_Deep() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
LEFT JOIN [Employees] AS [e#Manager] ON [e].[ReportsTo] = [e#Manager].[EmployeeID]
WHERE [e#Manager].[ReportsTo] IS NULL");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Single_Predicate() : 
            AssertSql(
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Take_simple_parameterized() : 
            AssertSql(
                @"@__p_0='10'

SELECT TOP @__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_multi_level_reference_and_collection_predicate(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 2 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o].[OrderID] = 10248
ORDER BY [o#Customer].[CustomerID]",
                //
                @"SELECT [o#Customer#Orders].[OrderID], [o#Customer#Orders].[CustomerID], [o#Customer#Orders].[EmployeeID], [o#Customer#Orders].[OrderDate]
FROM [Orders] AS [o#Customer#Orders]
INNER JOIN (
    SELECT DISTINCT [t].*
    FROM (
        SELECT TOP 1 [o#Customer0].[CustomerID]
        FROM [Orders] AS [o0]
        LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]
        WHERE [o0].[OrderID] = 10248
        ORDER BY [o#Customer0].[CustomerID]
    ) AS [t]
) AS [t0] ON [o#Customer#Orders].[CustomerID] = [t0].[CustomerID]
ORDER BY [t0].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_collection_complex_predicate_or() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI', 'ALFKI', 'ABCDE')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_with_multiple_conditions_still_uses_exists() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ([c].[City] = 'London') AND EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE ([o].[EmployeeID] = 1) AND ([c].[CustomerID] = [o].[CustomerID]))");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_expression_other_to_string() : 
            AssertSql(
                @"SELECT Str([o].[OrderDate]) AS [ShipName]
FROM [Orders] AS [o]
WHERE [o].[OrderDate] IS NOT NULL");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_last(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CompanyName] DESC, [c].[CustomerID] DESC",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID], [c0].[CompanyName]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CompanyName] DESC, [c0].[CustomerID] DESC
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CompanyName] DESC, [t].[CustomerID] DESC");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_last(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CompanyName] DESC, [c].[CustomerID] DESC",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID], [c0].[CompanyName]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CompanyName] DESC, [c0].[CustomerID] DESC
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CompanyName] DESC, [t].[CustomerID] DESC");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_where_skip_take_projection(Boolean useString) : 
            AssertSql(
                @"@__p_0='1'
@__p_1='2'

SELECT TOP @__p_1+@__p_0 [od#Order].[CustomerID]
FROM [Order Details] AS [od]
INNER JOIN [Orders] AS [od#Order] ON [od].[OrderID] = [od#Order].[OrderID]
WHERE [od].[Quantity] = 10
ORDER BY [od].[OrderID], [od].[ProductID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_where_skip_take_projection(Boolean useString) : 
            AssertSql(
                @"@__p_0='1'
@__p_1='2'

SELECT TOP @__p_1+@__p_0 [od#Order].[CustomerID]
FROM [Order Details] AS [od]
INNER JOIN [Orders] AS [od#Order] ON [od].[OrderID] = [od#Order].[OrderID]
WHERE [od].[Quantity] = 10
ORDER BY [od].[OrderID], [od].[ProductID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_join_select() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_math_sin() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
WHERE ([od].[OrderID] = 11077) AND (SIN([od].[Discount]) > 0E0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_skip_take() : 
            AssertSql(
                @"@__p_0='5'
@__p_1='8'

SELECT TOP @__p_1+@__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactTitle], [c].[ContactName]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_negated_boolean_expression_compared_to_another_negated_boolean_expression() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE IIf(
    [p].[ProductID] > 50,
    True,
    False
) = IIf(
    [p].[ProductID] > 20,
    True,
    False
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_StartsWith_Identity() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ([c].[ContactName] LIKE [c].[ContactName] + '%' AND (LEFT([c].[ContactName], LEN([c].[ContactName])) = [c].[ContactName])) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OfType_Select() : 
            AssertSql(
                @"SELECT TOP 1 [o#Customer].[City]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
ORDER BY [o].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.DTO_complex_distinct_where() : 
            AssertSql(
                @"SELECT [t].[Property]
FROM (
    SELECT DISTINCT [c].[CustomerID] + [c].[City] AS [Property]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[Property] = 'ALFKIBerlin'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_ternary_boolean_condition_true() : 
            AssertSql(
                @"@__flag_0='True'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE ((@__flag_0 = True) AND ([p].[UnitsInStock] >= 20)) OR ((@__flag_0 <> True) AND ([p].[UnitsInStock] < 20))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_collection_complex_predicate_not_matching_ins1() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ALFKI', 'ABCDE') OR [c].[CustomerID] NOT IN ('ABCDE', 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_client_side_negated() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_nested_collection_multi_level() : 
            AssertSql(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 3 [o].[OrderDate] AS [Date]
FROM [Orders] AS [o]
WHERE ([o].[OrderID] < 10500) AND (@_outer_CustomerID = [o].[CustomerID])",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT TOP 3 [o].[OrderDate] AS [Date]
FROM [Orders] AS [o]
WHERE ([o].[OrderID] < 10500) AND (@_outer_CustomerID = [o].[CustomerID])",
                //
                @"@_outer_CustomerID='ANTON' (Nullable = false) (Size = 5)

SELECT TOP 3 [o].[OrderDate] AS [Date]
FROM [Orders] AS [o]
WHERE ([o].[OrderID] < 10500) AND (@_outer_CustomerID = [o].[CustomerID])",
                //
                @"@_outer_CustomerID='AROUT' (Nullable = false) (Size = 5)

SELECT TOP 3 [o].[OrderDate] AS [Date]
FROM [Orders] AS [o]
WHERE ([o].[OrderID] < 10500) AND (@_outer_CustomerID = [o].[CustomerID])");



EntityFramework.Jet.FunctionalTests.QueryJetTest.IsNullOrEmpty_in_projection() : 
            AssertSql(
                @"SELECT [c].[CustomerID] AS [Id], IIf(
    [c].[Region] IS NULL OR ([c].[Region] = ''),
    True,
    False
) AS [Value]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_shadow_projection() : 
            AssertSql(
                @"SELECT [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[Title] = 'Sales Representative'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_closure_via_query_cache_nullable_type() : 
            AssertSql(
                @"@__reportsTo_0='2'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[ReportsTo] = @__reportsTo_0",
                //
                @"@__reportsTo_0='5'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[ReportsTo] = @__reportsTo_0",
                //
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[ReportsTo] IS NULL");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_nested_field_access_closure_via_query_cache() : 
            AssertSql(
                @"@__city_Nested_InstanceFieldValue_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_Nested_InstanceFieldValue_0",
                //
                @"@__city_Nested_InstanceFieldValue_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_Nested_InstanceFieldValue_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.GroupJoin_DefaultIfEmpty_Where() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Customers] AS [c]
LEFT JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [o].[OrderID] IS NOT NULL AND ([o].[CustomerID] = 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_constant_is_null() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested_negated() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE NOT EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A'))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Last() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactName] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_method_call_nullable_type_reverse_closure_via_query_cache() : 
            AssertSql(
                @"@__city_NullableInt_0='1'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[EmployeeID] > @__city_NullableInt_0",
                //
                @"@__city_NullableInt_0='5'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[EmployeeID] > @__city_NullableInt_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_subquery_closure_via_query_cache() : 
            AssertSql(
                @"@__customerID_0='ALFKI' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE ([o].[CustomerID] = @__customerID_0) AND ([o].[CustomerID] = [c].[CustomerID]))",
                //
                @"@__customerID_0='ANATR' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE ([o].[CustomerID] = @__customerID_0) AND ([o].[CustomerID] = [c].[CustomerID]))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_math_exp() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
WHERE ([od].[OrderID] = 11077) AND (EXP([od].[Discount]) > 1E0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Skip_Take() : 
            AssertSql(
                @"@__p_0='5'
@__p_1='10'

SELECT TOP @__p_1+@__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactName]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_de_morgan_or_optimizated() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE ([p].[Discontinued] = False) AND ([p].[ProductID] >= 20)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition() : 
            AssertSql(
                @"SELECT [e1].[EmployeeID], [e1].[City], [e1].[Country], [e1].[FirstName], [e1].[ReportsTo], [e1].[Title]
FROM [Employees] AS [e1]
WHERE [e1].[FirstName] = (
    SELECT TOP 1 [e].[FirstName]
    FROM [Employees] AS [e]
    ORDER BY [e].[EmployeeID]
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_scalar_primitive_after_take() : 
            AssertSql(
                @"@__p_0='9'

SELECT TOP @__p_0 [e].[EmployeeID]
FROM [Employees] AS [e]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.FirstOrDefault_inside_subquery_gets_server_evaluated() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ([c].[CustomerID] = 'ALFKI') AND ((
    SELECT TOP 1 [o].[CustomerID]
    FROM [Orders] AS [o]
    WHERE ([o].[CustomerID] = 'ALFKI') AND ([c].[CustomerID] = [o].[CustomerID])
) = 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.IsNullOrWhiteSpace_in_predicate() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[Region] IS NULL OR (LTRIM(RTRIM([c].[Region])) = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_array_closure() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI')",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Query_expression_with_to_string_and_contains() : 
            AssertSql(
                @"SELECT [o].[CustomerID]
FROM [Orders] AS [o]
WHERE [o].[OrderDate] IS NOT NULL AND (Instr(Str([o].[EmployeeID]), '10') > 0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Take_simple_projection() : 
            AssertSql(
                @"@__p_0='10'

SELECT TOP @__p_0 [c].[City]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_static_property_access_closure_via_query_cache() : 
            AssertSql(
                @"@__StaticPropertyValue_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__StaticPropertyValue_0",
                //
                @"@__StaticPropertyValue_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__StaticPropertyValue_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_subquery_on_bool() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE 'Chai' IN (
    SELECT [p2].[ProductName]
    FROM [Products] AS [p2]
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_client_deep_inside_predicate_and_server_top_level() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <> 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_collection_false() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] NOT IN ('ABCDE', 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_parameter_compared_to_binary_expression() : 
            AssertSql(
                @"@__prm_0='True'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE IIf(
    [p].[ProductID] > 50,
    True,
    False
) <> @__prm_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Last_when_no_order_by() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_anonymous_conditional_expression() : 
            AssertSql(
                @"SELECT [p].[ProductID], IIf(
    [p].[UnitsInStock] > 0,
    True,
    False
) AS [IsAvailable]
FROM [Products] AS [p]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_not_bool_member_compared_to_binary_expression() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] <> IIf(
    [p].[ProductID] > 50,
    True,
    False
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_orderby_join_select() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] <> 'ALFKI'
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition_entity_equality_no_elements_FirstOrDefault() : 
            AssertSql(
                @"SELECT [e1].[EmployeeID], [e1].[City], [e1].[Country], [e1].[FirstName], [e1].[ReportsTo], [e1].[Title]
FROM [Employees] AS [e1]
WHERE (
    SELECT TOP 1 [e2].[EmployeeID]
    FROM [Employees] AS [e2]
    WHERE [e2].[EmployeeID] = 42
) = 0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_math_cos() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
WHERE ([od].[OrderID] = 11077) AND (COS([od].[Discount]) > 0E0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested2() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (([c].[City] <> 'London') OR [c].[City] IS NULL) AND EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A'))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Count_with_predicate() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.GroupBy_anonymous_with_where() : 
            AssertSql(
                @"SELECT [c].[City], [c].[CustomerID]
FROM [Customers] AS [c]
WHERE [c].[Country] IN ('Argentina', 'Austria', 'Brazil', 'France', 'Germany', 'USA')
ORDER BY [c].[City]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_list_inline_closure_mix() : line_closure_mix() in C:\Develop\ForPlanning\EntityFrameworkCore.Jet\test\EFCore.Jet.FunctionalTests\QueryJetTest.cs:riga 6244
            AssertSql(
                @"@__id_0='ALFKI' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', @__id_0)",
                //
                @"@__id_0='ANATR' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', @__id_0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_closure_via_query_cache_nullable_type_reverse() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[ReportsTo] IS NULL",
                //
                @"@__reportsTo_0='5'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[ReportsTo] = @__reportsTo_0",
                //
                @"@__reportsTo_0='2'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[ReportsTo] = @__reportsTo_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_property_access_closure_via_query_cache() : 
            AssertSql(
                @"@__city_InstancePropertyValue_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_InstancePropertyValue_0",
                //
                @"@__city_InstancePropertyValue_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_InstancePropertyValue_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_null_is_not_null() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_Where_Count_with_predicate() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Orders] AS [o]
WHERE ([o].[OrderID] > 10) AND (([o].[CustomerID] <> 'ALFKI') OR [o].[CustomerID] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.IsNullOrEmpty_negated_in_projection() : 
            AssertSql(
                @"SELECT [c].[CustomerID] AS [Id], IIf(
    [c].[Region] IS NOT NULL AND ([c].[Region] <> ''),
    True,
    False
) AS [Value]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OfType_Select_OfType_Select() : 
            AssertSql(
                @"SELECT TOP 1 [o#Customer].[City]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
ORDER BY [o].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_Where_Subquery_Deep_Single() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
WHERE [od].[OrderID] = 10344",
                //
                @"@_outer_OrderID='10344'

SELECT TOP 2 [o0].[CustomerID]
FROM [Orders] AS [o0]
WHERE @_outer_OrderID = [o0].[OrderID]",
                //
                @"@_outer_CustomerID1='WHITC' (Nullable = false) (Size = 5)

SELECT TOP 2 [c2].[City]
FROM [Customers] AS [c2]
WHERE @_outer_CustomerID1 = [c2].[CustomerID]",
                //
                @"@_outer_OrderID='10344'

SELECT TOP 2 [o0].[CustomerID]
FROM [Orders] AS [o0]
WHERE @_outer_OrderID = [o0].[OrderID]",
                //
                @"@_outer_CustomerID1='WHITC' (Nullable = false) (Size = 5)

SELECT TOP 2 [c2].[City]
FROM [Customers] AS [c2]
WHERE @_outer_CustomerID1 = [c2].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_nested_property_access_closure_via_query_cache() : 
            AssertSql(
                @"@__city_Nested_InstancePropertyValue_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_Nested_InstancePropertyValue_0",
                //
                @"@__city_Nested_InstancePropertyValue_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_Nested_InstancePropertyValue_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_and_parameter_compared_to_binary_expression_nested() : 
            AssertSql(
                @"@__prm_0='True'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = IIf(
    IIf(
        [p].[ProductID] > 50,
        True,
        False
    ) <> @__prm_0,
    True,
    False
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_Last() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'
ORDER BY [c].[ContactName] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Contains_MethodCall() : 
            AssertSql(
                @"@__LocalMethod1_0='M' (Nullable = false) (Size = 1)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (Instr([c].[ContactName], @__LocalMethod1_0) > 0) OR (@__LocalMethod1_0 = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_compare_with_parameter() : 
            AssertSql(
                @"@__customer_CustomerID_0='ALFKI' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] > @__customer_CustomerID_0",
                //
                @"@__customer_CustomerID_0='ALFKI' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] < @__customer_CustomerID_0",
                //
                @"@__customer_CustomerID_0='ALFKI' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <= @__customer_CustomerID_0",
                //
                @"@__customer_CustomerID_0='ALFKI' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <= @__customer_CustomerID_0",
                //
                @"@__customer_CustomerID_0='ALFKI' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] >= @__customer_CustomerID_0",
                //
                @"@__customer_CustomerID_0='ALFKI' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] >= @__customer_CustomerID_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Anonymous_complex_distinct_where() : 
            AssertSql(
                @"SELECT [t].[A]
FROM (
    SELECT DISTINCT [c].[CustomerID] + [c].[City] AS [A]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[A] = 'ALFKIBerlin'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_equals_constant() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_field_access_closure_via_query_cache() : 
            AssertSql(
                @"@__city_InstanceFieldValue_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_InstanceFieldValue_0",
                //
                @"@__city_InstanceFieldValue_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_InstanceFieldValue_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_equals_on_matched_nullable_int_types() : 
            AssertSql(
                @"@__nullableIntPrm_0='2'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE @__nullableIntPrm_0 = [e].[ReportsTo]",
                //
                @"@__nullableIntPrm_0='2'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[ReportsTo] = @__nullableIntPrm_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_OrderBy_Count() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_ternary_boolean_condition_with_false_as_result_false() : 
            AssertSql(
                @"@__flag_0='False'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE (@__flag_0 = True) AND ([p].[UnitsInStock] >= 20)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Compare_multi_predicate() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] >= 'ALFKI' AND [c].[CustomerID] < 'CACTU'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[ContactTitle] = 'Owner' AND [c].[Country] <> 'USA'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.DTO_complex_distinct_result() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM (
    SELECT DISTINCT [c].[CustomerID] + [c].[City] AS [Property]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[Property] LIKE 'A' + '%' AND (LEFT([t].[Property], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_ternary_boolean_condition_with_false_as_result_true() : 
            AssertSql(
                @"@__flag_0='True'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE (@__flag_0 = True) AND ([p].[UnitsInStock] >= 20)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_new_instance_field_access_closure_via_query_cache() : 
            AssertSql(
                @"@__InstanceFieldValue_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__InstanceFieldValue_0",
                //
                @"@__InstanceFieldValue_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__InstanceFieldValue_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_compare_null() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] IS NULL AND ([c].[Country] = 'UK')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Entity_equality_local() : 
            AssertSql(
                @"@__local_0_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = @__local_0_CustomerID");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Queryable_simple_anonymous_projection_subquery() : 
            AssertSql(
                @"@__p_0='91'

SELECT TOP @__p_0 [c].[City]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_false() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = False");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_comparison_operator() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY IIf(
    [c].[Region] = 'ASK',
    True,
    False
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition_entity_equality_multiple_elements_FirstOrDefault() : 
            AssertSql(
                @"SELECT [e1].[EmployeeID], [e1].[City], [e1].[Country], [e1].[FirstName], [e1].[ReportsTo], [e1].[Title]
FROM [Employees] AS [e1]
WHERE (
    SELECT TOP 1 [e2].[EmployeeID]
    FROM [Employees] AS [e2]
    WHERE ([e2].[EmployeeID] <> [e1].[ReportsTo]) OR [e1].[ReportsTo] IS NULL
) = 0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_equals_using_object_overload_on_mismatched_types() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_collection_complex_predicate_and() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ALFKI', 'ABCDE') AND [c].[CustomerID] IN ('ABCDE', 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_shadow() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_equals_on_mismatched_types_nullable_long_nullable_int() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE False = True",
                //
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_StartsWith_Literal() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[ContactName] LIKE 'M' + '%' AND (LEFT([c].[ContactName], LEN('M')) = 'M')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition_entity_equality_one_element_FirstOrDefault() : 
            AssertSql(
                @"SELECT [e1].[EmployeeID], [e1].[City], [e1].[Country], [e1].[FirstName], [e1].[ReportsTo], [e1].[Title]
FROM [Employees] AS [e1]
WHERE (
    SELECT TOP 1 [e2].[EmployeeID]
    FROM [Employees] AS [e2]
    WHERE [e2].[EmployeeID] = [e1].[ReportsTo]
) = 0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_false_shadow() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = False");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_math_tan() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
WHERE ([od].[OrderID] = 11077) AND (TAN([od].[Discount]) > 0E0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_array_inline() : line() in C:\Develop\ForPlanning\EntityFrameworkCore.Jet\test\EFCore.Jet.FunctionalTests\QueryJetTest.cs:riga 6214
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_conditional_operator_where_condition_null() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY IIf(
    False = True,
    'ZZ',
    [c].[City]
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Last_Predicate() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'
ORDER BY [c].[ContactName] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Entity_equality_local_inline() : line() in C:\Develop\ForPlanning\EntityFrameworkCore.Jet\test\EFCore.Jet.FunctionalTests\QueryJetTest.cs:riga 175
            AssertSql(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ANATR'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.GroupJoin_Where() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Environment_newline_is_funcletized() : line_is_funcletized() in C:\Develop\ForPlanning\EntityFrameworkCore.Jet\test\EFCore.Jet.FunctionalTests\QueryJetTest.cs:riga 6640
            AssertSql(
                @"@__NewLine_0='
' (Nullable = false) (Size = 2)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (Instr([c].[CustomerID], @__NewLine_0) > 0) OR (@__NewLine_0 = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Compare_simple_one() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] > 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] < 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <= 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <= 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] >= 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] >= 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.LastOrDefault_Predicate() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'
ORDER BY [c].[ContactName] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_complex_negated_expression_optimized() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE (([p].[Discontinued] = False) AND ([p].[ProductID] < 60)) AND ([p].[ProductID] > 30)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_list_closure() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI')");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_alias_generation(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
ORDER BY [o].[OrderID]",
                //
                @"SELECT [o#OrderDetails].[OrderID], [o#OrderDetails].[ProductID], [o#OrderDetails].[Discount], [o#OrderDetails].[Quantity], [o#OrderDetails].[UnitPrice]
FROM [Order Details] AS [o#OrderDetails]
INNER JOIN (
    SELECT [o0].[OrderID]
    FROM [Orders] AS [o0]
) AS [t] ON [o#OrderDetails].[OrderID] = [t].[OrderID]
ORDER BY [t].[OrderID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_alias_generation(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
ORDER BY [o].[OrderID]",
                //
                @"SELECT [o#OrderDetails].[OrderID], [o#OrderDetails].[ProductID], [o#OrderDetails].[Discount], [o#OrderDetails].[Quantity], [o#OrderDetails].[UnitPrice]
FROM [Order Details] AS [o#OrderDetails]
INNER JOIN (
    SELECT [o0].[OrderID]
    FROM [Orders] AS [o0]
) AS [t] ON [o#OrderDetails].[OrderID] = [t].[OrderID]
ORDER BY [t].[OrderID]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Discriminator_used_when_projection_over_of_type() : 
            AssertSql(
                @"SELECT [k].[FoundOn]
FROM [Animal] AS [k]
WHERE [k].[Discriminator] = 'Kiwi'");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_query_all_types_when_shared_column() : 
            AssertSql(
                @"SELECT [d].[Id], [d].[Discriminator], [d].[CaffeineGrams], [d].[CokeCO2], [d].[SugarGrams], [d].[LiltCO2], [d].[HasMilk]
FROM [Drink] AS [d]
WHERE [d].[Discriminator] IN ('Tea', 'Lilt', 'Coke', 'Drink')");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_kiwi_where_north_on_derived_property() : 
            AssertSql(
                @"SELECT [x].[Species], [x].[CountryId], [x].[Discriminator], [x].[Name], [x].[EagleId], [x].[IsFlightless], [x].[FoundOn]
FROM [Animal] AS [x]
WHERE ([x].[Discriminator] = 'Kiwi') AND ([x].[FoundOn] = 0)");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_query_all_birds() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_include_prey() : 
            AssertSql(
                @"SELECT TOP 2 [e].[Species], [e].[CountryId], [e].[Discriminator], [e].[Name], [e].[EagleId], [e].[IsFlightless], [e].[Group]
FROM [Animal] AS [e]
WHERE [e].[Discriminator] = 'Eagle'
ORDER BY [e].[Species]",
                //
                @"SELECT [e#Prey].[Species], [e#Prey].[CountryId], [e#Prey].[Discriminator], [e#Prey].[Name], [e#Prey].[EagleId], [e#Prey].[IsFlightless], [e#Prey].[Group], [e#Prey].[FoundOn]
FROM [Animal] AS [e#Prey]
INNER JOIN (
    SELECT TOP 1 [e0].[Species]
    FROM [Animal] AS [e0]
    WHERE [e0].[Discriminator] = 'Eagle'
    ORDER BY [e0].[Species]
) AS [t] ON [e#Prey].[EagleId] = [t].[Species]
WHERE [e#Prey].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [t].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Discriminator_used_when_projection_over_derived_type() : 
            AssertSql(
                @"SELECT [k].[FoundOn]
FROM [Animal] AS [k]
WHERE [k].[Discriminator] = 'Kiwi'");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_animal() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_bird() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_query_when_shared_column() : 
            AssertSql(
                @"SELECT TOP 2 [d].[Id], [d].[Discriminator], [d].[CaffeineGrams], [d].[CokeCO2], [d].[SugarGrams]
FROM [Drink] AS [d]
WHERE [d].[Discriminator] = 'Coke'",
                //
                @"SELECT TOP 2 [d].[Id], [d].[Discriminator], [d].[LiltCO2], [d].[SugarGrams]
FROM [Drink] AS [d]
WHERE [d].[Discriminator] = 'Lilt'",
                //
                @"SELECT TOP 2 [d].[Id], [d].[Discriminator], [d].[CaffeineGrams], [d].[HasMilk]
FROM [Drink] AS [d]
WHERE [d].[Discriminator] = 'Tea'");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_kiwi_where_south_on_derived_property() : 
            AssertSql(
                @"SELECT [x].[Species], [x].[CountryId], [x].[Discriminator], [x].[Name], [x].[EagleId], [x].[IsFlightless], [x].[FoundOn]
FROM [Animal] AS [x]
WHERE ([x].[Discriminator] = 'Kiwi') AND ([x].[FoundOn] = 1)");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_is_kiwi_with_other_predicate() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle') AND (([a].[Discriminator] = 'Kiwi') AND ([a].[CountryId] = 1))");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_bird_with_projection() : 
            AssertSql(
                @"SELECT [b].[EagleId]
FROM [Animal] AS [b]
WHERE [b].[Discriminator] IN ('Kiwi', 'Eagle')");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_query_just_roses() : 
            AssertSql(
                @"SELECT TOP 2 [p].[Species], [p].[CountryId], [p].[Genus], [p].[Name], [p].[HasThorns]
FROM [Plant] AS [p]
WHERE [p].[Genus] = 0");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_alias_generation(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[ProductID], [o].[Discount], [o].[Quantity], [o].[UnitPrice], [o#Order].[OrderID], [o#Order].[CustomerID], [o#Order].[EmployeeID], [o#Order].[OrderDate]
FROM [Order Details] AS [o]
INNER JOIN [Orders] AS [o#Order] ON [o].[OrderID] = [o#Order].[OrderID]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_query_just_kiwis() : 
            AssertSql(
                @"SELECT TOP 2 [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] = 'Kiwi'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Compare_simple_zero() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <> 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] > 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <= 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] > 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <= 'ALFKI'");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_bird_first() : 
            AssertSql(
                @"SELECT TOP 1 [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Discriminator_used_when_projection_over_derived_type2() : 
            AssertSql(
                @"SELECT [b].[IsFlightless], [b].[Discriminator]
FROM [Animal] AS [b]
WHERE [b].[Discriminator] IN ('Kiwi', 'Eagle')");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_query_all_animals() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_Where_Count_with_predicate_client_eval_mixed() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE ([o].[CustomerID] <> 'ALFKI') OR [o].[CustomerID] IS NULL");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_method_call_closure_via_query_cache() : 
            AssertSql(
                @"@__GetCity_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__GetCity_0",
                //
                @"@__GetCity_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__GetCity_0");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_on_join_clause_with_order_by_and_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[City], [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT DISTINCT [c0].[CustomerID], [c0].[City]
    FROM [Customers] AS [c0]
    INNER JOIN [Orders] AS [o0] ON [c0].[CustomerID] = [o0].[CustomerID]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[City], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_dependent_already_tracked_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_dependent_already_tracked_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Where_subquery_on_navigation_client_eval() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [o4].[OrderID]
FROM [Orders] AS [o4]",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT [o2].[OrderID]
FROM [Orders] AS [o2]
WHERE @_outer_CustomerID = [o2].[CustomerID]",
                //
                @"SELECT [o4].[OrderID]
FROM [Orders] AS [o4]",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT [o2].[OrderID]
FROM [Orders] AS [o2]
WHERE @_outer_CustomerID = [o2].[CustomerID]",
                //
                @"SELECT [o4].[OrderID]
FROM [Orders] AS [o4]",
                //
                @"@_outer_CustomerID='ANTON' (Nullable = false) (Size = 5)

SELECT [o2].[OrderID]
FROM [Orders] AS [o2]
WHERE @_outer_CustomerID = [o2].[CustomerID]",
                //
                @"SELECT [o4].[OrderID]
FROM [Orders] AS [o4]",
                //
                @"@_outer_CustomerID='AROUT' (Nullable = false) (Size = 5)

SELECT [o2].[OrderID]
FROM [Orders] AS [o2]
WHERE @_outer_CustomerID = [o2].[CustomerID]");

Output truncated.

EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Navigations() : 
            AssertSql(
                @"SELECT [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Collection_select_nav_prop_first_or_default_then_nav_prop() : 
            AssertSql(
                @"SELECT [e].[CustomerID]
FROM [Customers] AS [e]
WHERE [e].[CustomerID] LIKE 'A' + '%' AND (LEFT([e].[CustomerID], LEN('A')) = 'A')
ORDER BY [e].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 1 [e#Customer].[CustomerID], [e#Customer].[Address], [e#Customer].[City], [e#Customer].[CompanyName], [e#Customer].[ContactName], [e#Customer].[ContactTitle], [e#Customer].[Country], [e#Customer].[Fax], [e#Customer].[Phone], [e#Customer].[PostalCode], [e#Customer].[Region]
FROM [Orders] AS [e0]
LEFT JOIN [Customers] AS [e#Customer] ON [e0].[CustomerID] = [e#Customer].[CustomerID]
WHERE [e0].[OrderID] IN (10643, 10692, 10702, 10835, 10952, 11011) AND (@_outer_CustomerID = [e0].[CustomerID])",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT TOP 1 [e#Customer].[CustomerID], [e#Customer].[Address], [e#Customer].[City], [e#Customer].[CompanyName], [e#Customer].[ContactName], [e#Customer].[ContactTitle], [e#Customer].[Country], [e#Customer].[Fax], [e#Customer].[Phone], [e#Customer].[PostalCode], [e#Customer].[Region]
FROM [Orders] AS [e0]
LEFT JOIN [Customers] AS [e#Customer] ON [e0].[CustomerID] = [e#Customer].[CustomerID]
WHERE [e0].[OrderID] IN (10643, 10692, 10702, 10835, 10952, 11011) AND (@_outer_CustomerID = [e0].[CustomerID])",
                //
                @"@_outer_CustomerID='ANTON' (Nullable = false) (Size = 5)

SELECT TOP 1 [e#Customer].[CustomerID], [e#Customer].[Address], [e#Customer].[City], [e#Customer].[CompanyName], [e#Customer].[ContactName], [e#Customer].[ContactTitle], [e#Customer].[Country], [e#Customer].[Fax], [e#Customer].[Phone], [e#Customer].[PostalCode], [e#Customer].[Region]
FROM [Orders] AS [e0]
LEFT JOIN [Customers] AS [e#Customer] ON [e0].[CustomerID] = [e#Customer].[CustomerID]
WHERE [e0].[OrderID] IN (10643, 10692, 10702, 10835, 10952, 11011) AND (@_outer_CustomerID = [e0].[CustomerID])",
                //
                @"@_outer_CustomerID='AROUT' (Nullable = false) (Size = 5)

SELECT TOP 1 [e#Customer].[CustomerID], [e#Customer].[Address], [e#Customer].[City], [e#Customer].[CompanyName], [e#Customer].[ContactName], [e#Customer].[ContactTitle], [e#Customer].[Country], [e#Customer].[Fax], [e#Customer].[Phone], [e#Customer].[PostalCode], [e#Customer].[Region]
FROM [Orders] AS [e0]
LEFT JOIN [Customers] AS [e#Customer] ON [e0].[CustomerID] = [e#Customer].[CustomerID]
WHERE [e0].[OrderID] IN (10643, 10692, 10702, 10835, 10952, 11011) AND (@_outer_CustomerID = [e0].[CustomerID])");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Navigation_fk_based_inside_contains() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] IN ('ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_client_and_server_top_level() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <> 'AROUT'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_shadow() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[Title] = 'Sales Representative'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_project_filter() : 
            AssertSql(
                @"SELECT [c].[CompanyName]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Select_inverted_boolean() : 
            AssertSql(
                @"SELECT [w].[Id], IIf(
    [w].[IsAutomatic] = False,
    True,
    False
) AS [Manual]
FROM [Weapon] AS [w]
WHERE [w].[IsAutomatic] = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_select_many() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
, [Orders] AS [o]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_StartsWith_MethodCall() : 
            AssertSql(
                @"@__LocalMethod1_0='M' (Nullable = false) (Size = 1)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ([c].[ContactName] LIKE @__LocalMethod1_0 + '%' AND (LEFT([c].[ContactName], LEN(@__LocalMethod1_0)) = @__LocalMethod1_0)) OR (@__LocalMethod1_0 = '')");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Sum_with_optional_navigation_is_translated_to_sql() : 
            AssertSql(
                @"SELECT SUM([g].[SquadId])
FROM [Gear] AS [g]
LEFT JOIN [CogTag] AS [g#Tag] ON ([g].[Nickname] = [g#Tag].[GearNickName]) AND ([g].[SquadId] = [g#Tag].[GearSquadId])
WHERE [g].[Discriminator] IN ('Officer', 'Gear') AND (([g#Tag].[Note] <> 'Foo') OR [g#Tag].[Note] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_equals_method_string() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_kiwi() : 
            AssertSql(
                @"SELECT [k].[Species], [k].[CountryId], [k].[Discriminator], [k].[Name], [k].[EagleId], [k].[IsFlightless], [k].[FoundOn]
FROM [Animal] AS [k]
WHERE ([k].[Discriminator] = 'Kiwi') AND ([k].[CountryId] = 1)");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_bird_first() : 
            AssertSql(
                @"SELECT TOP 1 [b].[Species], [b].[CountryId], [b].[Discriminator], [b].[Name], [b].[EagleId], [b].[IsFlightless], [b].[Group], [b].[FoundOn]
FROM [Animal] AS [b]
WHERE [b].[Discriminator] IN ('Kiwi', 'Eagle') AND ([b].[CountryId] = 1)
ORDER BY [b].[Species]");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_is_kiwi_in_projection() : 
            AssertSql(
                @"SELECT IIf(
    [a].[Discriminator] = 'Kiwi',
    True,
    False
)
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle') AND ([a].[CountryId] = 1)");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_bird_with_projection() : 
            AssertSql(
                @"SELECT [b].[EagleId]
FROM [Animal] AS [b]
WHERE [b].[Discriminator] IN ('Kiwi', 'Eagle') AND ([b].[CountryId] = 1)");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_is_kiwi() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE ([a].[Discriminator] IN ('Kiwi', 'Eagle') AND ([a].[CountryId] = 1)) AND ([a].[Discriminator] = 'Kiwi')");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_bird_predicate() : 
            AssertSql(
                @"SELECT [b].[Species], [b].[CountryId], [b].[Discriminator], [b].[Name], [b].[EagleId], [b].[IsFlightless], [b].[Group], [b].[FoundOn]
FROM [Animal] AS [b]
WHERE ([b].[Discriminator] IN ('Kiwi', 'Eagle') AND ([b].[CountryId] = 1)) AND ([b].[CountryId] = 1)
ORDER BY [b].[Species]");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_animal() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle') AND ([a].[CountryId] = 1)
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Entity_equality_empty() : 
            AssertSql(
                @"SELECT [g].[Nickname], [g].[SquadId], [g].[AssignedCityName], [g].[CityOrBirthName], [g].[Discriminator], [g].[FullName], [g].[HasSoulPatch], [g].[LeaderNickname], [g].[LeaderSquadId], [g].[Rank]
FROM [Gear] AS [g]
WHERE [g].[Discriminator] IN ('Officer', 'Gear') AND ([g].[Nickname] IS NULL AND ([g].[SquadId] = 0))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_expression_int_to_string() : 
            AssertSql(
                @"SELECT Str([o].[OrderID]) AS [ShipName]
FROM [Orders] AS [o]
WHERE [o].[OrderDate] IS NOT NULL");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_dependent_already_tracked(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_on_join_clause_with_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT DISTINCT [c0].[CustomerID]
    FROM [Customers] AS [c0]
    INNER JOIN [Orders] AS [o0] ON [c0].[CustomerID] = [o0].[CustomerID]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_on_join_clause_with_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT DISTINCT [c0].[CustomerID]
    FROM [Customers] AS [c0]
    INNER JOIN [Orders] AS [o0] ON [c0].[CustomerID] = [o0].[CustomerID]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_project_filter2() : 
            AssertSql(
                @"SELECT [c].[City]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_conditional_operator() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY IIf(
    [c].[Region] IS NULL,
    'ZZ',
    [c].[Region]
)");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_then_include_collection(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID], [c#Orders].[OrderID]",
                //
                @"SELECT [c#Orders#OrderDetails].[OrderID], [c#Orders#OrderDetails].[ProductID], [c#Orders#OrderDetails].[Discount], [c#Orders#OrderDetails].[Quantity], [c#Orders#OrderDetails].[UnitPrice]
FROM [Order Details] AS [c#Orders#OrderDetails]
INNER JOIN (
    SELECT DISTINCT [c#Orders0].[OrderID], [t0].[CustomerID]
    FROM [Orders] AS [c#Orders0]
    INNER JOIN (
        SELECT [c1].[CustomerID]
        FROM [Customers] AS [c1]
    ) AS [t0] ON [c#Orders0].[CustomerID] = [t0].[CustomerID]
) AS [t1] ON [c#Orders#OrderDetails].[OrderID] = [t1].[OrderID]
ORDER BY [t1].[CustomerID], [t1].[OrderID]");



EntityFramework.Jet.FunctionalTests.FiltersJetTest.Compiled_query() : 
            AssertSql(
                @"@__customerID='BERGS' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = @__customerID",
                //
                @"@__customerID='BLAUS' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = @__customerID");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_then_include_collection(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID], [c#Orders].[OrderID]",
                //
                @"SELECT [c#Orders#OrderDetails].[OrderID], [c#Orders#OrderDetails].[ProductID], [c#Orders#OrderDetails].[Discount], [c#Orders#OrderDetails].[Quantity], [c#Orders#OrderDetails].[UnitPrice]
FROM [Order Details] AS [c#Orders#OrderDetails]
INNER JOIN (
    SELECT DISTINCT [c#Orders0].[OrderID], [t0].[CustomerID]
    FROM [Orders] AS [c#Orders0]
    INNER JOIN (
        SELECT [c1].[CustomerID]
        FROM [Customers] AS [c1]
    ) AS [t0] ON [c#Orders0].[CustomerID] = [t0].[CustomerID]
) AS [t1] ON [c#Orders#OrderDetails].[OrderID] = [t1].[OrderID]
ORDER BY [t1].[CustomerID], [t1].[OrderID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_order_by_non_key_with_first_or_default(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CompanyName] DESC, [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID], [c0].[CompanyName]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CompanyName] DESC, [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CompanyName] DESC, [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_order_by_non_key_with_first_or_default(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CompanyName] DESC, [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID], [c0].[CompanyName]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CompanyName] DESC, [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CompanyName] DESC, [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_with_filter_reordered(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_with_filter_reordered(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Where_Navigation_Equals_Navigation() : 
            AssertSql(
                @"SELECT [o1].[OrderID], [o1].[CustomerID], [o1].[EmployeeID], [o1].[OrderDate], [o2].[OrderID], [o2].[CustomerID], [o2].[EmployeeID], [o2].[OrderDate]
FROM [Orders] AS [o1]
, [Orders] AS [o2]
WHERE ([o1].[CustomerID] = [o2].[CustomerID]) OR ([o1].[CustomerID] IS NULL AND [o2].[CustomerID] IS NULL)");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Contains_Column() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (Instr([c].[ContactName], [c].[ContactName]) > 0) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Contains_Identity() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (Instr([c].[ContactName], [c].[ContactName]) > 0) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_reversed() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE 'London' = [c].[City]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_concat_with_navigation2() : 
            AssertSql(
                @"SELECT ([o#Customer].[City] + ' ') + [o#Customer].[City]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_filter_reordered(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_filter_reordered(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.GroupJoin_with_nav_projected_in_subquery_when_client_eval() : 
            AssertSql(
                @"SELECT [od0].[OrderID], [od0].[ProductID], [od0].[Discount], [od0].[Quantity], [od0].[UnitPrice], [od#Product0].[ProductID], [od#Product0].[Discontinued], [od#Product0].[ProductName], [od#Product0].[UnitPrice], [od#Product0].[UnitsInStock]
FROM [Order Details] AS [od0]
INNER JOIN [Products] AS [od#Product0] ON [od0].[ProductID] = [od#Product0].[ProductID]",
                //
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [o#Customer0].[CustomerID], [o#Customer0].[Address], [o#Customer0].[City], [o#Customer0].[CompanyName], [o#Customer0].[ContactName], [o#Customer0].[ContactTitle], [o#Customer0].[Country], [o#Customer0].[Fax], [o#Customer0].[Phone], [o#Customer0].[PostalCode], [o#Customer0].[Region]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_collection_navigation_simple() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] LIKE 'A' + '%' AND (LEFT([c0].[CustomerID], LEN('A')) = 'A')
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.SelectMany_projection2() : 
            AssertSql(
                @"SELECT [e1].[City], [e2].[Country], [e3].[FirstName]
FROM [Employees] AS [e1]
, [Employees] AS [e2]
, [Employees] AS [e3]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_static_field_access_closure_via_query_cache() : 
            AssertSql(
                @"@__StaticFieldValue_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__StaticFieldValue_0",
                //
                @"@__StaticFieldValue_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__StaticFieldValue_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested_negated3() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE NOT EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A')) AND (([c].[City] <> 'London') OR [c].[City] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_subquery_involving_join_binds_to_correct_table() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE ([o].[OrderID] > 11000) AND [o].[OrderID] IN (
    SELECT [od].[OrderID]
    FROM [Order Details] AS [od]
    INNER JOIN [Products] AS [od#Product] ON [od].[ProductID] = [od#Product].[ProductID]
    WHERE [od#Product].[ProductName] = 'Chai'
)");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Collection_where_nav_prop_all_client() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='ANTON' (Nullable = false) (Size = 5)

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='AROUT' (Nullable = false) (Size = 5)

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='BERGS' (Nullable = false) (Size = 5)

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='BLAUS' (Nullable = false) (Size = 5)

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='BLONP' (Nullable = false) (Size = 5)

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='BOLID' (Nullable = false) (Size = 5)

SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]");

Output truncated.

EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Navigations_Where_Navigations() : 
            AssertSql(
                @"SELECT [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE ([o#Customer].[City] = 'Seattle') AND (([o#Customer].[Phone] <> '555 555 5555') OR [o#Customer].[Phone] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A'))");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Singleton_Navigation_With_Member_Access() : 
            AssertSql(
                @"SELECT [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City] AS [B], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE ([o#Customer].[City] = 'Seattle') AND (([o#Customer].[Phone] <> '555 555 5555') OR [o#Customer].[Phone] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_not_in_optimization2() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region], [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Customers] AS [c]
, [Employees] AS [e]
WHERE [c].[City] NOT IN ('London', 'Berlin')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_correlated_subquery_ordered() : 
            AssertSql(
                @"@__p_0='3'

SELECT TOP @__p_0 [c].[CustomerID]
FROM [Customers] AS [c]",
                //
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]",
                //
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]",
                //
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]",
                //
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]",
                //
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]",
                //
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Where_Navigation_Contains() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE Instr([o#Customer].[City], 'Sea') > 0");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Where_Navigation() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o#Customer].[City] = 'Seattle'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_when_groupby(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[City], [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID], [c0].[City]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[City], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_when_groupby(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[City], [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID], [c0].[City]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[City], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_last_no_orderby(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID] DESC",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CustomerID] DESC
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID] DESC");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_last_no_orderby(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID] DESC",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CustomerID] DESC
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID] DESC");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Collection_select_nav_prop_single_or_default_then_nav_prop_nested() : 
            AssertSql(
                @"SELECT 1
FROM [Customers] AS [e]
WHERE [e].[CustomerID] LIKE 'A' + '%' AND (LEFT([e].[CustomerID], LEN('A')) = 'A')",
                //
                @"SELECT TOP 2 [o#Customer0].[City]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]
WHERE [o0].[OrderID] = 10643",
                //
                @"SELECT TOP 2 [o#Customer0].[City]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]
WHERE [o0].[OrderID] = 10643",
                //
                @"SELECT TOP 2 [o#Customer0].[City]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]
WHERE [o0].[OrderID] = 10643",
                //
                @"SELECT TOP 2 [o#Customer0].[City]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]
WHERE [o0].[OrderID] = 10643");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_collection_FirstOrDefault_project_entity() : 
            AssertSql(
                @"@__p_0='2'

SELECT TOP @__p_0 [c].[CustomerID]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_DTO_with_member_init_distinct_in_subquery_used_in_projection_translated_to_server() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region], [t].[Id], [t].[Count]
FROM [Customers] AS [c]
, (
    SELECT DISTINCT [o].[CustomerID] AS [Id], [o].[OrderID] AS [Count]
    FROM [Orders] AS [o]
    WHERE [o].[OrderID] < 10300
) AS [t]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.LastOrDefault() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactName] DESC");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_dependent_already_tracked(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_dependent_already_tracked(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.GroupJoin_with_nav_in_predicate_in_subquery_when_client_eval() : 
            AssertSql(
                @"SELECT [od0].[OrderID], [od0].[ProductID], [od0].[Discount], [od0].[Quantity], [od0].[UnitPrice], [od#Product0].[ProductID], [od#Product0].[Discontinued], [od#Product0].[ProductName], [od#Product0].[UnitPrice], [od#Product0].[UnitsInStock]
FROM [Order Details] AS [od0]
INNER JOIN [Products] AS [od#Product0] ON [od0].[ProductID] = [od#Product0].[ProductID]",
                //
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [o#Customer0].[CustomerID], [o#Customer0].[Address], [o#Customer0].[City], [o#Customer0].[CompanyName], [o#Customer0].[ContactName], [o#Customer0].[ContactTitle], [o#Customer0].[Country], [o#Customer0].[Fax], [o#Customer0].[Phone], [o#Customer0].[PostalCode], [o#Customer0].[Region]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Project_single_entity_value_subquery_works() : 
            AssertSql(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]
ORDER BY [o].[OrderID]",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]
ORDER BY [o].[OrderID]",
                //
                @"@_outer_CustomerID='ANTON' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]
ORDER BY [o].[OrderID]",
                //
                @"@_outer_CustomerID='AROUT' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]
ORDER BY [o].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.GroupJoin_with_nav_in_orderby_in_subquery_when_client_eval() : 
            AssertSql(
                @"SELECT [od0].[OrderID], [od0].[ProductID], [od0].[Discount], [od0].[Quantity], [od0].[UnitPrice], [od#Product0].[ProductID], [od#Product0].[Discontinued], [od#Product0].[ProductName], [od#Product0].[UnitPrice], [od#Product0].[UnitsInStock]
FROM [Order Details] AS [od0]
INNER JOIN [Products] AS [od#Product0] ON [od0].[ProductID] = [od#Product0].[ProductID]",
                //
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [o#Customer0].[CustomerID], [o#Customer0].[Address], [o#Customer0].[City], [o#Customer0].[CompanyName], [o#Customer0].[ContactName], [o#Customer0].[ContactTitle], [o#Customer0].[Country], [o#Customer0].[Fax], [o#Customer0].[Phone], [o#Customer0].[PostalCode], [o#Customer0].[Region]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Take_Select_Navigation() : 
            AssertSql(
                @"@__p_0='2'

SELECT TOP @__p_0 [c].[CustomerID]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_conditional_order_by(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY IIf(
    [c].[CustomerID] LIKE 'S' + '%' AND (LEFT([c].[CustomerID], LEN('S')) = 'S'),
    1,
    2
), [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID], IIf(
        [c0].[CustomerID] LIKE 'S' + '%' AND (LEFT([c0].[CustomerID], LEN('S')) = 'S'),
        1,
        2
    ) AS [c]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[c], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Let_group_by_nav_prop() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice], [od#Order].[CustomerID] AS [customer]
FROM [Order Details] AS [od]
INNER JOIN [Orders] AS [od#Order] ON [od].[OrderID] = [od#Order].[OrderID]
ORDER BY [od#Order].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Where_Navigation_Included() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o#Customer].[City] = 'Seattle'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Take_simple() : 
            AssertSql(
                @"@__p_0='10'

SELECT TOP @__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_order_by_key(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Join_with_nav_in_predicate_in_subquery_when_client_eval() : 
            AssertSql(
                @"SELECT [od0].[OrderID], [od0].[ProductID], [od0].[Discount], [od0].[Quantity], [od0].[UnitPrice], [od#Product0].[ProductID], [od#Product0].[Discontinued], [od#Product0].[ProductName], [od#Product0].[UnitPrice], [od#Product0].[UnitsInStock]
FROM [Order Details] AS [od0]
INNER JOIN [Products] AS [od#Product0] ON [od0].[ProductID] = [od#Product0].[ProductID]",
                //
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [o#Customer0].[CustomerID], [o#Customer0].[Address], [o#Customer0].[City], [o#Customer0].[CompanyName], [o#Customer0].[ContactName], [o#Customer0].[ContactTitle], [o#Customer0].[Country], [o#Customer0].[Fax], [o#Customer0].[Phone], [o#Customer0].[PostalCode], [o#Customer0].[Region]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Where_Navigation_Client() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Navigation_inside_contains() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o#Customer].[City] IN ('Novigrad', 'Seattle')");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_collection_FirstOrDefault_project_anonymous_type() : 
            AssertSql(
                @"@__p_0='2'

SELECT TOP @__p_0 [c].[CustomerID]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[CustomerID], [o].[OrderID]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[CustomerID], [o].[OrderID]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Where_Navigation_Multiple_Access() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE ([o#Customer].[City] = 'Seattle') AND (([o#Customer].[Phone] <> '555 555 5555') OR [o#Customer].[Phone] IS NULL)");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_principal_already_tracked(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_nested_collection_multi_level5() : 
            AssertSql(
                @"SELECT (
    SELECT TOP 1 (
        SELECT TOP 1 [od].[ProductID]
        FROM [Order Details] AS [od]
        WHERE ([od].[OrderID] <> (
            SELECT COUNT(*)
            FROM [Orders] AS [o0]
            WHERE [c].[CustomerID] = [o0].[CustomerID]
        )) AND ([o].[OrderID] = [od].[OrderID])
    )
    FROM [Orders] AS [o]
    WHERE ([o].[OrderID] < 10500) AND ([c].[CustomerID] = [o].[CustomerID])
) AS [Order]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_with_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_with_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested_negated2() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (([c].[City] <> 'London') OR [c].[City] IS NULL) AND NOT EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A'))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Take_subquery_projection() : 
            AssertSql(
                @"@__p_0='2'

SELECT TOP @__p_0 [c].[City]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_with_skip(Boolean useString) : 
            AssertSql(
                @"@__p_0='80'

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactName], [c].[CustomerID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_with_skip(Boolean useString) : 
            AssertSql(
                @"@__p_0='80'

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactName], [c].[CustomerID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_negated_twice() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_nested_collection_count_using_DTO() : 
            AssertSql(
                @"SELECT [c].[CustomerID] AS [Id], (
    SELECT COUNT(*)
    FROM [Orders] AS [o]
    WHERE [c].[CustomerID] = [o].[CustomerID]
) AS [Count]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Collection_select_nav_prop_all_client() : 
            AssertSql(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='ANTON' (Nullable = false) (Size = 5)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='AROUT' (Nullable = false) (Size = 5)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='BERGS' (Nullable = false) (Size = 5)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='BLAUS' (Nullable = false) (Size = 5)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='BLONP' (Nullable = false) (Size = 5)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]",
                //
                @"@_outer_CustomerID='BOLID' (Nullable = false) (Size = 5)

SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate]
FROM [Orders] AS [o0]
WHERE @_outer_CustomerID = [o0].[CustomerID]");

Output truncated.

EntityFramework.Jet.FunctionalTests.QueryJetTest.Anonymous_complex_distinct_result() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM (
    SELECT DISTINCT [c].[CustomerID] + [c].[City] AS [A]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[A] LIKE 'A' + '%' AND (LEFT([t].[A], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_EndsWith_Column() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (RIGHT([c].[ContactName], LEN([c].[ContactName])) = [c].[ContactName]) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Substring_with_client_eval() : 
            AssertSql(
                @"SELECT TOP 1 [c].[ContactName]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_multi_level_reference_and_collection_predicate(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 2 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o].[OrderID] = 10248
ORDER BY [o#Customer].[CustomerID]",
                //
                @"SELECT [o#Customer#Orders].[OrderID], [o#Customer#Orders].[CustomerID], [o#Customer#Orders].[EmployeeID], [o#Customer#Orders].[OrderDate]
FROM [Orders] AS [o#Customer#Orders]
INNER JOIN (
    SELECT DISTINCT [t].*
    FROM (
        SELECT TOP 1 [o#Customer0].[CustomerID]
        FROM [Orders] AS [o0]
        LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]
        WHERE [o0].[OrderID] = 10248
        ORDER BY [o#Customer0].[CustomerID]
    ) AS [t]
) AS [t0] ON [o#Customer#Orders].[CustomerID] = [t0].[CustomerID]
ORDER BY [t0].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_multi_level_reference_and_collection_predicate(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 2 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o].[OrderID] = 10248
ORDER BY [o#Customer].[CustomerID]",
                //
                @"SELECT [o#Customer#Orders].[OrderID], [o#Customer#Orders].[CustomerID], [o#Customer#Orders].[EmployeeID], [o#Customer#Orders].[OrderDate]
FROM [Orders] AS [o#Customer#Orders]
INNER JOIN (
    SELECT DISTINCT [t].*
    FROM (
        SELECT TOP 1 [o#Customer0].[CustomerID]
        FROM [Orders] AS [o0]
        LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]
        WHERE [o0].[OrderID] = 10248
        ORDER BY [o#Customer0].[CustomerID]
    ) AS [t]
) AS [t0] ON [o#Customer#Orders].[CustomerID] = [t0].[CustomerID]
ORDER BY [t0].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_parameter() : 
            AssertSql(
                @"@__prm_0='True'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE @__prm_0 = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_not_in_optimization4() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region], [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Customers] AS [c]
, [Employees] AS [e]
WHERE [c].[City] NOT IN ('London', 'Berlin', 'Seattle', 'Lisboa')");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_last(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CompanyName] DESC, [c].[CustomerID] DESC",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID], [c0].[CompanyName]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CompanyName] DESC, [c0].[CustomerID] DESC
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CompanyName] DESC, [t].[CustomerID] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.DTO_member_distinct_where() : 
            AssertSql(
                @"SELECT [t].[Property]
FROM (
    SELECT DISTINCT [c].[CustomerID] AS [Property]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[Property] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_where_skip_take_projection(Boolean useString) : 
            AssertSql(
                @"@__p_0='1'
@__p_1='2'

SELECT TOP @__p_1+@__p_0 [od#Order].[CustomerID]
FROM [Order Details] AS [od]
INNER JOIN [Orders] AS [od#Order] ON [od].[OrderID] = [od#Order].[OrderID]
WHERE [od].[Quantity] = 10
ORDER BY [od].[OrderID], [od].[ProductID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_where_skip_take_projection(Boolean useString) : 
            AssertSql(
                @"@__p_0='1'
@__p_1='2'

SELECT TOP @__p_1+@__p_0 [od#Order].[CustomerID]
FROM [Order Details] AS [od]
INNER JOIN [Orders] AS [od#Order] ON [od].[OrderID] = [od#Order].[OrderID]
WHERE [od].[Quantity] = 10
ORDER BY [od].[OrderID], [od].[ProductID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_nested_collection_multi_level3() : 
            AssertSql(
                @"SELECT (
    SELECT TOP 1 [o].[OrderDate]
    FROM [Orders] AS [o]
    WHERE ([o].[OrderID] < 10500) AND ([c].[CustomerID] = [o].[CustomerID])
) AS [OrderDates]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.SelectMany_Count() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Customers] AS [c]
, [Orders] AS [o]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_shadow_subquery_FirstOrDefault() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[Title] = (
    SELECT TOP 1 [e2].[Title]
    FROM [Employees] AS [e2]
    ORDER BY [e2].[Title]
)");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_on_additional_from_clause_with_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c1]
, [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT DISTINCT [c0].[CustomerID]
    FROM [Customers] AS [c10]
    , [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_false() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.DTO_member_distinct_result() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM (
    SELECT DISTINCT [c].[CustomerID] AS [Property]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[Property] LIKE 'A' + '%' AND (LEFT([t].[Property], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_equals_using_int_overload_on_mismatched_types() : 
            AssertSql(
                @"@__shortPrm_0='1'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[EmployeeID] = @__shortPrm_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_EndsWith_Identity() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (RIGHT([c].[ContactName], LEN([c].[ContactName])) = [c].[ContactName]) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_de_morgan_and_optimizated() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE ([p].[Discontinued] = False) OR ([p].[ProductID] >= 20)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Local_array() : 
            AssertSql(
                @"@__get_Item_0='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = @__get_Item_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Join_Customers_Orders_Skip_Take() : 
            AssertSql(
                @"@__p_0='10'
@__p_1='5'

SELECT TOP @__p_1+@__p_0 [c].[ContactName], [o].[OrderID]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
ORDER BY [o].[OrderID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_expression_long_to_string() : 
            AssertSql(
                @"SELECT Str([o].[OrderID]) AS [ShipName]
FROM [Orders] AS [o]
WHERE [o].[OrderDate] IS NOT NULL");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Distinct_Take() : 
            AssertSql(
                @"@__p_0='5'

SELECT TOP @__p_0 [t].[OrderID], [t].[CustomerID], [t].[EmployeeID], [t].[OrderDate]
FROM (
    SELECT DISTINCT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
    FROM [Orders] AS [o]
) AS [t]
ORDER BY [t].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_collection_sql_injection() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ALFKI', 'ABC'')); GO; DROP TABLE Orders; GO; --', 'ALFKI', 'ABCDE')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested3() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A')) AND (([c].[City] <> 'London') OR [c].[City] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.SelectMany_projection1() : 
            AssertSql(
                @"SELECT [e1].[City], [e2].[Country]
FROM [Employees] AS [e1]
, [Employees] AS [e2]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_EndsWith_MethodCall() : 
            AssertSql(
                @"@__LocalMethod2_0='m' (Nullable = false) (Size = 1)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (RIGHT([c].[ContactName], LEN(@__LocalMethod2_0)) = @__LocalMethod2_0) OR (@__LocalMethod2_0 = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_closure_via_query_cache() : 
            AssertSql(
                @"@__city_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_0",
                //
                @"@__city_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_expression_invoke() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Anonymous_member_distinct_result() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM (
    SELECT DISTINCT [c].[CustomerID]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[CustomerID] LIKE 'A' + '%' AND (LEFT([t].[CustomerID], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Join_Customers_Orders_Projection_With_String_Concat_Skip_Take() : 
            AssertSql(
                @"@__p_0='10'
@__p_1='5'

SELECT TOP @__p_1+@__p_0 ([c].[ContactName] + ' ') + [c].[ContactTitle] AS [Contact], [o].[OrderID]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
ORDER BY [o].[OrderID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_select_many_or3() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region], [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Customers] AS [c]
, [Employees] AS [e]
WHERE [c].[City] IN ('London', 'Berlin', 'Seattle')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_compared_to_binary_expression() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = IIf(
    [p].[ProductID] > 50,
    True,
    False
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Null_conditional_simple() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_comparison_to_nullable_bool() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE RIGHT([c].[CustomerID], LEN('KI')) = 'KI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_subquery_and_local_array_closure() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Customers] AS [c1]
    WHERE [c1].[City] IN ('London', 'Buenos Aires') AND ([c1].[CustomerID] = [c].[CustomerID]))",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Customers] AS [c1]
    WHERE [c1].[City] IN ('London') AND ([c1].[CustomerID] = [c].[CustomerID]))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_many_cross_join_same_collection() : 
            AssertSql(
                @"SELECT [c0].[CustomerID], [c0].[Address], [c0].[City], [c0].[CompanyName], [c0].[ContactName], [c0].[ContactTitle], [c0].[Country], [c0].[Fax], [c0].[Phone], [c0].[PostalCode], [c0].[Region]
FROM [Customers] AS [c]
, [Customers] AS [c0]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_LastOrDefault() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'
ORDER BY [c].[ContactName] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Contains_Literal() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE Instr([c].[ContactName], 'M') > 0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_equals_on_mismatched_types_nullable_int_long() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE False = True",
                //
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_ternary_boolean_condition_false() : 
            AssertSql(
                @"@__flag_0='False'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE ((@__flag_0 = True) AND ([p].[UnitsInStock] >= 20)) OR ((@__flag_0 <> True) AND ([p].[UnitsInStock] < 20))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Single_Predicate() : 
            AssertSql(
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Take_simple_parameterized() : 
            AssertSql(
                @"@__p_0='10'

SELECT TOP @__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_collection_complex_predicate_or() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI', 'ALFKI', 'ABCDE')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_select_many_and() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region], [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Customers] AS [c]
, [Employees] AS [e]
WHERE (([c].[City] = 'London') AND ([c].[Country] = 'UK')) AND (([e].[City] = 'London') AND ([e].[Country] = 'UK'))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_with_multiple_conditions_still_uses_exists() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ([c].[City] = 'London') AND EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE ([o].[EmployeeID] = 1) AND ([c].[CustomerID] = [o].[CustomerID]))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_expression_other_to_string() : 
            AssertSql(
                @"SELECT Str([o].[OrderDate]) AS [ShipName]
FROM [Orders] AS [o]
WHERE [o].[OrderDate] IS NOT NULL");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_join_select() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_math_sin() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
WHERE ([od].[OrderID] = 11077) AND (SIN([od].[Discount]) > 0E0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_skip_take() : 
            AssertSql(
                @"@__p_0='5'
@__p_1='8'

SELECT TOP @__p_1+@__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactTitle], [c].[ContactName]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_in_optimization_multiple() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region], [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Customers] AS [c]
, [Employees] AS [e]
WHERE ([c].[City] IN ('London', 'Berlin') OR ([c].[CustomerID] = 'ALFKI')) OR ([c].[CustomerID] = 'ABCDE')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_negated_boolean_expression_compared_to_another_negated_boolean_expression() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE IIf(
    [p].[ProductID] > 50,
    True,
    False
) = IIf(
    [p].[ProductID] > 20,
    True,
    False
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_StartsWith_Identity() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ([c].[ContactName] LIKE [c].[ContactName] + '%' AND (LEFT([c].[ContactName], LEN([c].[ContactName])) = [c].[ContactName])) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OfType_Select() : 
            AssertSql(
                @"SELECT TOP 1 [o#Customer].[City]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
ORDER BY [o].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.DTO_complex_distinct_where() : 
            AssertSql(
                @"SELECT [t].[Property]
FROM (
    SELECT DISTINCT [c].[CustomerID] + [c].[City] AS [Property]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[Property] = 'ALFKIBerlin'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_select_many_or_with_parameter() : 
            AssertSql(
                @"@__lisboa_1='Lisboa' (Nullable = false) (Size = 6)
@__london_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region], [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Customers] AS [c]
, [Employees] AS [e]
WHERE [c].[City] IN (@__london_0, 'Berlin', 'Seattle', @__lisboa_1)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.SelectMany_entity_deep() : 
            AssertSql(
                @"SELECT [e1].[EmployeeID], [e1].[City], [e1].[Country], [e1].[FirstName], [e1].[ReportsTo], [e1].[Title], [e2].[EmployeeID], [e2].[City], [e2].[Country], [e2].[FirstName], [e2].[ReportsTo], [e2].[Title], [e3].[EmployeeID], [e3].[City], [e3].[Country], [e3].[FirstName], [e3].[ReportsTo], [e3].[Title], [e4].[EmployeeID], [e4].[City], [e4].[Country], [e4].[FirstName], [e4].[ReportsTo], [e4].[Title]
FROM [Employees] AS [e1]
, [Employees] AS [e2]
, [Employees] AS [e3]
, [Employees] AS [e4]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_ternary_boolean_condition_true() : 
            AssertSql(
                @"@__flag_0='True'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE ((@__flag_0 = True) AND ([p].[UnitsInStock] >= 20)) OR ((@__flag_0 <> True) AND ([p].[UnitsInStock] < 20))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_collection_complex_predicate_not_matching_ins1() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ALFKI', 'ABCDE') OR [c].[CustomerID] NOT IN ('ABCDE', 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_client_side_negated() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_nested_collection_multi_level() : 
            AssertSql(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 3 [o].[OrderDate] AS [Date]
FROM [Orders] AS [o]
WHERE ([o].[OrderID] < 10500) AND (@_outer_CustomerID = [o].[CustomerID])",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT TOP 3 [o].[OrderDate] AS [Date]
FROM [Orders] AS [o]
WHERE ([o].[OrderID] < 10500) AND (@_outer_CustomerID = [o].[CustomerID])",
                //
                @"@_outer_CustomerID='ANTON' (Nullable = false) (Size = 5)

SELECT TOP 3 [o].[OrderDate] AS [Date]
FROM [Orders] AS [o]
WHERE ([o].[OrderID] < 10500) AND (@_outer_CustomerID = [o].[CustomerID])",
                //
                @"@_outer_CustomerID='AROUT' (Nullable = false) (Size = 5)

SELECT TOP 3 [o].[OrderDate] AS [Date]
FROM [Orders] AS [o]
WHERE ([o].[OrderID] < 10500) AND (@_outer_CustomerID = [o].[CustomerID])");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_SelectMany() : 
            AssertSql(
                @"SELECT [c].[ContactName], [t].[OrderID]
FROM [Customers] AS [c]
, (
    SELECT TOP 3 [o].*
    FROM [Orders] AS [o]
    ORDER BY [o].[OrderID]
) AS [t]
WHERE [c].[CustomerID] = [t].[CustomerID]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.IsNullOrEmpty_in_projection() : 
            AssertSql(
                @"SELECT [c].[CustomerID] AS [Id], IIf(
    [c].[Region] IS NULL OR ([c].[Region] = ''),
    True,
    False
) AS [Value]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_shadow_projection() : 
            AssertSql(
                @"SELECT [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[Title] = 'Sales Representative'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_closure_via_query_cache_nullable_type() : 
            AssertSql(
                @"@__reportsTo_0='2'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[ReportsTo] = @__reportsTo_0",
                //
                @"@__reportsTo_0='5'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[ReportsTo] = @__reportsTo_0",
                //
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[ReportsTo] IS NULL");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_nested_field_access_closure_via_query_cache() : 
            AssertSql(
                @"@__city_Nested_InstanceFieldValue_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_Nested_InstanceFieldValue_0",
                //
                @"@__city_Nested_InstanceFieldValue_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_Nested_InstanceFieldValue_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.GroupJoin_DefaultIfEmpty_Where() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Customers] AS [c]
LEFT JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [o].[OrderID] IS NOT NULL AND ([o].[CustomerID] = 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_constant_is_null() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested_negated() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE NOT EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A'))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Last() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactName] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_method_call_nullable_type_reverse_closure_via_query_cache() : 
            AssertSql(
                @"@__city_NullableInt_0='1'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[EmployeeID] > @__city_NullableInt_0",
                //
                @"@__city_NullableInt_0='5'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[EmployeeID] > @__city_NullableInt_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_subquery_closure_via_query_cache() : 
            AssertSql(
                @"@__customerID_0='ALFKI' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE ([o].[CustomerID] = @__customerID_0) AND ([o].[CustomerID] = [c].[CustomerID]))",
                //
                @"@__customerID_0='ANATR' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE ([o].[CustomerID] = @__customerID_0) AND ([o].[CustomerID] = [c].[CustomerID]))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_math_exp() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
WHERE ([od].[OrderID] = 11077) AND (EXP([od].[Discount]) > 1E0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Skip_Take() : 
            AssertSql(
                @"@__p_0='5'
@__p_1='10'

SELECT TOP @__p_1+@__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactName]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_de_morgan_or_optimizated() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE ([p].[Discontinued] = False) AND ([p].[ProductID] >= 20)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition() : 
            AssertSql(
                @"SELECT [e1].[EmployeeID], [e1].[City], [e1].[Country], [e1].[FirstName], [e1].[ReportsTo], [e1].[Title]
FROM [Employees] AS [e1]
WHERE [e1].[FirstName] = (
    SELECT TOP 1 [e].[FirstName]
    FROM [Employees] AS [e]
    ORDER BY [e].[EmployeeID]
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_scalar_primitive_after_take() : 
            AssertSql(
                @"@__p_0='9'

SELECT TOP @__p_0 [e].[EmployeeID]
FROM [Employees] AS [e]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.FirstOrDefault_inside_subquery_gets_server_evaluated() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ([c].[CustomerID] = 'ALFKI') AND ((
    SELECT TOP 1 [o].[CustomerID]
    FROM [Orders] AS [o]
    WHERE ([o].[CustomerID] = 'ALFKI') AND ([c].[CustomerID] = [o].[CustomerID])
) = 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_orderby_select_many() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
, [Orders] AS [o]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.IsNullOrWhiteSpace_in_predicate() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[Region] IS NULL OR (LTRIM(RTRIM([c].[Region])) = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_array_closure() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI')",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Subquery_is_null_translated_correctly() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (
    SELECT TOP 1 [o].[CustomerID]
    FROM [Orders] AS [o]
    WHERE [c].[CustomerID] = [o].[CustomerID]
    ORDER BY [o].[OrderID] DESC
) IS NULL");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_nested_collection_multi_level4() : 
            AssertSql(
                @"SELECT (
    SELECT TOP 1 (
        SELECT COUNT(*)
        FROM [Order Details] AS [od]
        WHERE ([od].[OrderID] > 10) AND ([o].[OrderID] = [od].[OrderID])
    )
    FROM [Orders] AS [o]
    WHERE ([o].[OrderID] < 10500) AND ([c].[CustomerID] = [o].[CustomerID])
) AS [Order]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Handle_materialization_properly_when_more_than_two_query_sources_are_involved() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
, [Orders] AS [o]
, [Employees] AS [e]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Query_expression_with_to_string_and_contains() : 
            AssertSql(
                @"SELECT [o].[CustomerID]
FROM [Orders] AS [o]
WHERE [o].[OrderDate] IS NOT NULL AND (Instr(Str([o].[EmployeeID]), '10') > 0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Take_simple_projection() : 
            AssertSql(
                @"@__p_0='10'

SELECT TOP @__p_0 [c].[City]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_static_property_access_closure_via_query_cache() : 
            AssertSql(
                @"@__StaticPropertyValue_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__StaticPropertyValue_0",
                //
                @"@__StaticPropertyValue_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__StaticPropertyValue_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_subquery_on_bool() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE 'Chai' IN (
    SELECT [p2].[ProductName]
    FROM [Products] AS [p2]
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_Where_Subquery_Deep_First() : 
            AssertSql(
                @"@__p_0='2'

SELECT TOP @__p_0 [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
WHERE (
    SELECT TOP 1 (
        SELECT TOP 1 [c].[City]
        FROM [Customers] AS [c]
        WHERE [o].[CustomerID] = [c].[CustomerID]
    )
    FROM [Orders] AS [o]
    WHERE [od].[OrderID] = [o].[OrderID]
) = 'Seattle'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_client_deep_inside_predicate_and_server_top_level() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <> 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Subquery_is_not_null_translated_correctly() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (
    SELECT TOP 1 [o].[CustomerID]
    FROM [Orders] AS [o]
    WHERE [c].[CustomerID] = [o].[CustomerID]
    ORDER BY [o].[OrderID] DESC
) IS NOT NULL");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_collection_false() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] NOT IN ('ABCDE', 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_parameter_compared_to_binary_expression() : 
            AssertSql(
                @"@__prm_0='True'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE IIf(
    [p].[ProductID] > 50,
    True,
    False
) <> @__prm_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Last_when_no_order_by() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_anonymous_conditional_expression() : 
            AssertSql(
                @"SELECT [p].[ProductID], IIf(
    [p].[UnitsInStock] > 0,
    True,
    False
) AS [IsAvailable]
FROM [Products] AS [p]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_not_bool_member_compared_to_binary_expression() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] <> IIf(
    [p].[ProductID] > 50,
    True,
    False
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_orderby_join_select() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] <> 'ALFKI'
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_DTO_with_member_init_distinct_in_subquery_translated_to_server() : 
            AssertSql(
                @"SELECT [t].[Id], [t].[Count], [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM (
    SELECT DISTINCT [o].[CustomerID] AS [Id], [o].[OrderID] AS [Count]
    FROM [Orders] AS [o]
    WHERE [o].[OrderID] < 10300
) AS [t]
, [Customers] AS [c]
WHERE [c].[CustomerID] = [t].[Id]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition_entity_equality_no_elements_FirstOrDefault() : 
            AssertSql(
                @"SELECT [e1].[EmployeeID], [e1].[City], [e1].[Country], [e1].[FirstName], [e1].[ReportsTo], [e1].[Title]
FROM [Employees] AS [e1]
WHERE (
    SELECT TOP 1 [e2].[EmployeeID]
    FROM [Employees] AS [e2]
    WHERE [e2].[EmployeeID] = 42
) = 0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_not_in_optimization1() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region], [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Customers] AS [c]
, [Employees] AS [e]
WHERE (([c].[City] <> 'London') OR [c].[City] IS NULL) AND (([e].[City] <> 'London') OR [e].[City] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_math_cos() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
WHERE ([od].[OrderID] = 11077) AND (COS([od].[Discount]) > 0E0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_not_in_optimization3() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region], [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Customers] AS [c]
, [Employees] AS [e]
WHERE [c].[City] NOT IN ('London', 'Berlin', 'Seattle')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.SelectMany_simple2() : 
            AssertSql(
                @"SELECT [e1].[EmployeeID], [e1].[City], [e1].[Country], [e1].[FirstName], [e1].[ReportsTo], [e1].[Title], [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region], [e2].[FirstName] AS [FirstName0]
FROM [Employees] AS [e1]
, [Customers] AS [c]
, [Employees] AS [e2]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested2() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (([c].[City] <> 'London') OR [c].[City] IS NULL) AND EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A'))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Count_with_predicate() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.GroupBy_anonymous_with_where() : 
            AssertSql(
                @"SELECT [c].[City], [c].[CustomerID]
FROM [Customers] AS [c]
WHERE [c].[Country] IN ('Argentina', 'Austria', 'Brazil', 'France', 'Germany', 'USA')
ORDER BY [c].[City]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_list_inline_closure_mix() : line_closure_mix() in C:\Develop\ForPlanning\EntityFrameworkCore.Jet\test\EFCore.Jet.FunctionalTests\QueryJetTest.cs:riga 6242
            AssertSql(
                @"@__id_0='ALFKI' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', @__id_0)",
                //
                @"@__id_0='ANATR' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', @__id_0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_closure_via_query_cache_nullable_type_reverse() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[ReportsTo] IS NULL",
                //
                @"@__reportsTo_0='5'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[ReportsTo] = @__reportsTo_0",
                //
                @"@__reportsTo_0='2'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[ReportsTo] = @__reportsTo_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_property_access_closure_via_query_cache() : 
            AssertSql(
                @"@__city_InstancePropertyValue_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_InstancePropertyValue_0",
                //
                @"@__city_InstancePropertyValue_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_InstancePropertyValue_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_select_many_or2() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region], [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Customers] AS [c]
, [Employees] AS [e]
WHERE [c].[City] IN ('London', 'Berlin')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_null_is_not_null() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_Where_Count_with_predicate() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Orders] AS [o]
WHERE ([o].[OrderID] > 10) AND (([o].[CustomerID] <> 'ALFKI') OR [o].[CustomerID] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.IsNullOrEmpty_negated_in_projection() : 
            AssertSql(
                @"SELECT [c].[CustomerID] AS [Id], IIf(
    [c].[Region] IS NOT NULL AND ([c].[Region] <> ''),
    True,
    False
) AS [Value]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OfType_Select_OfType_Select() : 
            AssertSql(
                @"SELECT TOP 1 [o#Customer].[City]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
ORDER BY [o].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_Where_Subquery_Deep_Single() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
WHERE [od].[OrderID] = 10344",
                //
                @"@_outer_OrderID='10344'

SELECT TOP 2 [o0].[CustomerID]
FROM [Orders] AS [o0]
WHERE @_outer_OrderID = [o0].[OrderID]",
                //
                @"@_outer_CustomerID1='WHITC' (Nullable = false) (Size = 5)

SELECT TOP 2 [c2].[City]
FROM [Customers] AS [c2]
WHERE @_outer_CustomerID1 = [c2].[CustomerID]",
                //
                @"@_outer_OrderID='10344'

SELECT TOP 2 [o0].[CustomerID]
FROM [Orders] AS [o0]
WHERE @_outer_OrderID = [o0].[OrderID]",
                //
                @"@_outer_CustomerID1='WHITC' (Nullable = false) (Size = 5)

SELECT TOP 2 [c2].[City]
FROM [Customers] AS [c2]
WHERE @_outer_CustomerID1 = [c2].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_nested_property_access_closure_via_query_cache() : 
            AssertSql(
                @"@__city_Nested_InstancePropertyValue_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_Nested_InstancePropertyValue_0",
                //
                @"@__city_Nested_InstancePropertyValue_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_Nested_InstancePropertyValue_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_and_parameter_compared_to_binary_expression_nested() : 
            AssertSql(
                @"@__prm_0='True'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = IIf(
    IIf(
        [p].[ProductID] > 50,
        True,
        False
    ) <> @__prm_0,
    True,
    False
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_Last() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'
ORDER BY [c].[ContactName] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Contains_MethodCall() : 
            AssertSql(
                @"@__LocalMethod1_0='M' (Nullable = false) (Size = 1)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (Instr([c].[ContactName], @__LocalMethod1_0) > 0) OR (@__LocalMethod1_0 = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_compare_with_parameter() : 
            AssertSql(
                @"@__customer_CustomerID_0='ALFKI' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] > @__customer_CustomerID_0",
                //
                @"@__customer_CustomerID_0='ALFKI' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] < @__customer_CustomerID_0",
                //
                @"@__customer_CustomerID_0='ALFKI' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <= @__customer_CustomerID_0",
                //
                @"@__customer_CustomerID_0='ALFKI' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <= @__customer_CustomerID_0",
                //
                @"@__customer_CustomerID_0='ALFKI' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] >= @__customer_CustomerID_0",
                //
                @"@__customer_CustomerID_0='ALFKI' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] >= @__customer_CustomerID_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Anonymous_complex_distinct_where() : 
            AssertSql(
                @"SELECT [t].[A]
FROM (
    SELECT DISTINCT [c].[CustomerID] + [c].[City] AS [A]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[A] = 'ALFKIBerlin'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_equals_constant() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_field_access_closure_via_query_cache() : 
            AssertSql(
                @"@__city_InstanceFieldValue_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_InstanceFieldValue_0",
                //
                @"@__city_InstanceFieldValue_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_InstanceFieldValue_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_equals_on_matched_nullable_int_types() : 
            AssertSql(
                @"@__nullableIntPrm_0='2'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE @__nullableIntPrm_0 = [e].[ReportsTo]",
                //
                @"@__nullableIntPrm_0='2'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[ReportsTo] = @__nullableIntPrm_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_OrderBy_Count() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_ternary_boolean_condition_with_false_as_result_false() : 
            AssertSql(
                @"@__flag_0='False'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE (@__flag_0 = True) AND ([p].[UnitsInStock] >= 20)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Compare_multi_predicate() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] >= 'ALFKI' AND [c].[CustomerID] < 'CACTU'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[ContactTitle] = 'Owner' AND [c].[Country] <> 'USA'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.DTO_complex_distinct_result() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM (
    SELECT DISTINCT [c].[CustomerID] + [c].[City] AS [Property]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[Property] LIKE 'A' + '%' AND (LEFT([t].[Property], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_ternary_boolean_condition_with_false_as_result_true() : 
            AssertSql(
                @"@__flag_0='True'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE (@__flag_0 = True) AND ([p].[UnitsInStock] >= 20)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_new_instance_field_access_closure_via_query_cache() : 
            AssertSql(
                @"@__InstanceFieldValue_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__InstanceFieldValue_0",
                //
                @"@__InstanceFieldValue_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__InstanceFieldValue_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_compare_null() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] IS NULL AND ([c].[Country] = 'UK')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Entity_equality_local() : 
            AssertSql(
                @"@__local_0_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = @__local_0_CustomerID");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Queryable_simple_anonymous_projection_subquery() : 
            AssertSql(
                @"@__p_0='91'

SELECT TOP @__p_0 [c].[City]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_false() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = False");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_comparison_operator() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY IIf(
    [c].[Region] = 'ASK',
    True,
    False
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition_entity_equality_multiple_elements_FirstOrDefault() : 
            AssertSql(
                @"SELECT [e1].[EmployeeID], [e1].[City], [e1].[Country], [e1].[FirstName], [e1].[ReportsTo], [e1].[Title]
FROM [Employees] AS [e1]
WHERE (
    SELECT TOP 1 [e2].[EmployeeID]
    FROM [Employees] AS [e2]
    WHERE ([e2].[EmployeeID] <> [e1].[ReportsTo]) OR [e1].[ReportsTo] IS NULL
) = 0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_equals_using_object_overload_on_mismatched_types() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.SelectMany_simple1() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title], [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Employees] AS [e]
, [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_collection_complex_predicate_and() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ALFKI', 'ABCDE') AND [c].[CustomerID] IN ('ABCDE', 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_shadow() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_equals_on_mismatched_types_nullable_long_nullable_int() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE False = True",
                //
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_StartsWith_Literal() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[ContactName] LIKE 'M' + '%' AND (LEFT([c].[ContactName], LEN('M')) = 'M')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition_entity_equality_one_element_FirstOrDefault() : 
            AssertSql(
                @"SELECT [e1].[EmployeeID], [e1].[City], [e1].[Country], [e1].[FirstName], [e1].[ReportsTo], [e1].[Title]
FROM [Employees] AS [e1]
WHERE (
    SELECT TOP 1 [e2].[EmployeeID]
    FROM [Employees] AS [e2]
    WHERE [e2].[EmployeeID] = [e1].[ReportsTo]
) = 0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_false_shadow() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = False");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_math_tan() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
WHERE ([od].[OrderID] = 11077) AND (TAN([od].[Discount]) > 0E0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_array_inline() : line() in C:\Develop\ForPlanning\EntityFrameworkCore.Jet\test\EFCore.Jet.FunctionalTests\QueryJetTest.cs:riga 6212
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_conditional_operator_where_condition_null() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY IIf(
    False = True,
    'ZZ',
    [c].[City]
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Last_Predicate() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'
ORDER BY [c].[ContactName] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Entity_equality_local_inline() : line() in C:\Develop\ForPlanning\EntityFrameworkCore.Jet\test\EFCore.Jet.FunctionalTests\QueryJetTest.cs:riga 173
            AssertSql(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ANATR'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_nested_collection_multi_level2() : 
            AssertSql(
                @"SELECT (
    SELECT TOP 1 [o].[OrderDate]
    FROM [Orders] AS [o]
    WHERE ([o].[OrderID] < 10500) AND ([c].[CustomerID] = [o].[CustomerID])
) AS [OrderDates]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.GroupJoin_Where() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Environment_newline_is_funcletized() : line_is_funcletized() in C:\Develop\ForPlanning\EntityFrameworkCore.Jet\test\EFCore.Jet.FunctionalTests\QueryJetTest.cs:riga 6638
            AssertSql(
                @"@__NewLine_0='
' (Nullable = false) (Size = 2)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (Instr([c].[CustomerID], @__NewLine_0) > 0) OR (@__NewLine_0 = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Compare_simple_one() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] > 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] < 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <= 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <= 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] >= 'ALFKI'",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] >= 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.LastOrDefault_Predicate() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'
ORDER BY [c].[ContactName] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_complex_negated_expression_optimized() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE (([p].[Discontinued] = False) AND ([p].[ProductID] < 60)) AND ([p].[ProductID] > 30)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_list_closure() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI')");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Discriminator_used_when_projection_over_of_type() : 
            AssertSql(
                @"SELECT [k].[FoundOn]
FROM [Animal] AS [k]
WHERE [k].[Discriminator] = 'Kiwi'");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_query_all_types_when_shared_column() : 
            AssertSql(
                @"SELECT [d].[Id], [d].[Discriminator], [d].[CaffeineGrams], [d].[CokeCO2], [d].[SugarGrams], [d].[LiltCO2], [d].[HasMilk]
FROM [Drink] AS [d]
WHERE [d].[Discriminator] IN ('Tea', 'Lilt', 'Coke', 'Drink')");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_kiwi_where_north_on_derived_property() : 
            AssertSql(
                @"SELECT [x].[Species], [x].[CountryId], [x].[Discriminator], [x].[Name], [x].[EagleId], [x].[IsFlightless], [x].[FoundOn]
FROM [Animal] AS [x]
WHERE ([x].[Discriminator] = 'Kiwi') AND ([x].[FoundOn] = 0)");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_query_all_birds() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_include_prey() : 
            AssertSql(
                @"SELECT TOP 2 [e].[Species], [e].[CountryId], [e].[Discriminator], [e].[Name], [e].[EagleId], [e].[IsFlightless], [e].[Group]
FROM [Animal] AS [e]
WHERE [e].[Discriminator] = 'Eagle'
ORDER BY [e].[Species]",
                //
                @"SELECT [e#Prey].[Species], [e#Prey].[CountryId], [e#Prey].[Discriminator], [e#Prey].[Name], [e#Prey].[EagleId], [e#Prey].[IsFlightless], [e#Prey].[Group], [e#Prey].[FoundOn]
FROM [Animal] AS [e#Prey]
INNER JOIN (
    SELECT TOP 1 [e0].[Species]
    FROM [Animal] AS [e0]
    WHERE [e0].[Discriminator] = 'Eagle'
    ORDER BY [e0].[Species]
) AS [t] ON [e#Prey].[EagleId] = [t].[Species]
WHERE [e#Prey].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [t].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Discriminator_used_when_projection_over_derived_type() : 
            AssertSql(
                @"SELECT [k].[FoundOn]
FROM [Animal] AS [k]
WHERE [k].[Discriminator] = 'Kiwi'");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_animal() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_bird() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_query_when_shared_column() : 
            AssertSql(
                @"SELECT TOP 2 [d].[Id], [d].[Discriminator], [d].[CaffeineGrams], [d].[CokeCO2], [d].[SugarGrams]
FROM [Drink] AS [d]
WHERE [d].[Discriminator] = 'Coke'",
                //
                @"SELECT TOP 2 [d].[Id], [d].[Discriminator], [d].[LiltCO2], [d].[SugarGrams]
FROM [Drink] AS [d]
WHERE [d].[Discriminator] = 'Lilt'",
                //
                @"SELECT TOP 2 [d].[Id], [d].[Discriminator], [d].[CaffeineGrams], [d].[HasMilk]
FROM [Drink] AS [d]
WHERE [d].[Discriminator] = 'Tea'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_Where_Count_with_predicate_client_eval_mixed() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE ([o].[CustomerID] <> 'ALFKI') OR [o].[CustomerID] IS NULL");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_bird_predicate() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle') AND ([a].[CountryId] = 1)
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_is_kiwi_in_projection() : 
            AssertSql(
                @"SELECT IIf(
    [a].[Discriminator] = 'Kiwi',
    True,
    False
)
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle')");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_query_just_kiwis() : 
            AssertSql(
                @"SELECT TOP 2 [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] = 'Kiwi'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_alias_generation(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
ORDER BY [o].[OrderID]",
                //
                @"SELECT [o#OrderDetails].[OrderID], [o#OrderDetails].[ProductID], [o#OrderDetails].[Discount], [o#OrderDetails].[Quantity], [o#OrderDetails].[UnitPrice]
FROM [Order Details] AS [o#OrderDetails]
INNER JOIN (
    SELECT [o0].[OrderID]
    FROM [Orders] AS [o0]
) AS [t] ON [o#OrderDetails].[OrderID] = [t].[OrderID]
ORDER BY [t].[OrderID]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_filter_all_animals() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle') AND ([a].[Name] = 'Great spotted kiwi')
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_kiwi() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] = 'Kiwi'");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_is_kiwi() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle') AND ([a].[Discriminator] = 'Kiwi')");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_use_of_type_bird_first() : 
            AssertSql(
                @"SELECT TOP 1 [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Discriminator_used_when_projection_over_derived_type2() : 
            AssertSql(
                @"SELECT [b].[IsFlightless], [b].[Discriminator]
FROM [Animal] AS [b]
WHERE [b].[Discriminator] IN ('Kiwi', 'Eagle')");



EntityFramework.Jet.FunctionalTests.InheritanceJetTest.Can_query_all_animals() : 
            AssertSql(
                @"SELECT [a].[Species], [a].[CountryId], [a].[Discriminator], [a].[Name], [a].[EagleId], [a].[IsFlightless], [a].[Group], [a].[FoundOn]
FROM [Animal] AS [a]
WHERE [a].[Discriminator] IN ('Kiwi', 'Eagle')
ORDER BY [a].[Species]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_select_many() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
, [Orders] AS [o]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_StartsWith_MethodCall() : 
            AssertSql(
                @"@__LocalMethod1_0='M' (Nullable = false) (Size = 1)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ([c].[ContactName] LIKE @__LocalMethod1_0 + '%' AND (LEFT([c].[ContactName], LEN(@__LocalMethod1_0)) = @__LocalMethod1_0)) OR (@__LocalMethod1_0 = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.First_inside_subquery_gets_client_evaluated() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 1 [o0].[CustomerID]
FROM [Orders] AS [o0]
WHERE ([o0].[CustomerID] = 'ALFKI') AND (@_outer_CustomerID = [o0].[CustomerID])");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_Count_with_predicate() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_equals_method_string() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Filter_coalesce_operator() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE IIf(IsNull([c].[CompanyName]), [c].[ContactName], [c].[CompanyName]) = 'The Big Cheese'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_alias_generation(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
ORDER BY [o].[OrderID]",
                //
                @"SELECT [o#OrderDetails].[OrderID], [o#OrderDetails].[ProductID], [o#OrderDetails].[Discount], [o#OrderDetails].[Quantity], [o#OrderDetails].[UnitPrice]
FROM [Order Details] AS [o#OrderDetails]
INNER JOIN (
    SELECT [o0].[OrderID]
    FROM [Orders] AS [o0]
) AS [t] ON [o#OrderDetails].[OrderID] = [t].[OrderID]
ORDER BY [t].[OrderID]");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Include_on_GroupJoin_SelectMany_DefaultIfEmpty_with_inheritance_and_coalesce_result() : 
            AssertSql(
                @"SELECT [g].[Nickname], [g].[SquadId], [g].[AssignedCityName], [g].[CityOrBirthName], [g].[Discriminator], [g].[FullName], [g].[HasSoulPatch], [g].[LeaderNickname], [g].[LeaderSquadId], [g].[Rank], [t].[Nickname], [t].[SquadId], [t].[AssignedCityName], [t].[CityOrBirthName], [t].[Discriminator], [t].[FullName], [t].[HasSoulPatch], [t].[LeaderNickname], [t].[LeaderSquadId], [t].[Rank]
FROM [Gear] AS [g]
LEFT JOIN (
    SELECT [g2].*
    FROM [Gear] AS [g2]
    WHERE [g2].[Discriminator] = 'Officer'
) AS [t] ON [g].[LeaderNickname] = [t].[Nickname]
WHERE [g].[Discriminator] IN ('Officer', 'Gear')
ORDER BY [t].[FullName], [g].[FullName]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_Subquery_Single() : 
            AssertSql(
                @"@__p_0='2'

SELECT TOP @__p_0 [od].[OrderID]
FROM [Order Details] AS [od]
ORDER BY [od].[ProductID], [od].[OrderID]",
                //
                @"@_outer_OrderID='10285'

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_OrderID = [o].[OrderID]
ORDER BY [o].[OrderID]",
                //
                @"@_outer_OrderID='10294'

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_OrderID = [o].[OrderID]
ORDER BY [o].[OrderID]");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Select_ternary_operation_with_has_value_not_null() : 
            AssertSql(
                @"SELECT [w].[Id], IIf(
    [w].[AmmunitionType] IS NOT NULL AND ([w].[AmmunitionType] = 1),
    'Yes',
    'No'
) AS [IsCartidge]
FROM [Weapon] AS [w]
WHERE [w].[AmmunitionType] IS NOT NULL AND ([w].[AmmunitionType] = 1)");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Select_inverted_boolean() : 
            AssertSql(
                @"SELECT [w].[Id], IIf(
    [w].[IsAutomatic] = False,
    True,
    False
) AS [Manual]
FROM [Weapon] AS [w]
WHERE [w].[IsAutomatic] = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bitwise_or() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (IIf(
    [c].[CustomerID] = 'ALFKI',
    True,
    False
) BOR IIf(
    [c].[CustomerID] = 'ANATR',
    True,
    False
)) = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_expression_int_to_string() : 
            AssertSql(
                @"SELECT Str([o].[OrderID]) AS [ShipName]
FROM [Orders] AS [o]
WHERE [o].[OrderDate] IS NOT NULL");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Sum_with_optional_navigation_is_translated_to_sql() : 
            AssertSql(
                @"SELECT SUM([g].[SquadId])
FROM [Gear] AS [g]
LEFT JOIN [CogTag] AS [g#Tag] ON ([g].[Nickname] = [g#Tag].[GearNickName]) AND ([g].[SquadId] = [g#Tag].[GearSquadId])
WHERE [g].[Discriminator] IN ('Officer', 'Gear') AND (([g#Tag].[Note] <> 'Foo') OR [g#Tag].[Note] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_project_filter2() : 
            AssertSql(
                @"SELECT [c].[City]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_alias_generation(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[ProductID], [o].[Discount], [o].[Quantity], [o].[UnitPrice], [o#Order].[OrderID], [o#Order].[CustomerID], [o#Order].[EmployeeID], [o#Order].[OrderDate]
FROM [Order Details] AS [o]
INNER JOIN [Orders] AS [o#Order] ON [o].[OrderID] = [o#Order].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_conditional_operator() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY IIf(
    [c].[Region] IS NULL,
    'ZZ',
    [c].[Region]
)");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Collection_select_nav_prop_first_or_default_then_nav_prop() : 
            AssertSql(
                @"SELECT [e].[CustomerID]
FROM [Customers] AS [e]
WHERE [e].[CustomerID] LIKE 'A' + '%' AND (LEFT([e].[CustomerID], LEN('A')) = 'A')
ORDER BY [e].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 1 [e#Customer].[CustomerID], [e#Customer].[Address], [e#Customer].[City], [e#Customer].[CompanyName], [e#Customer].[ContactName], [e#Customer].[ContactTitle], [e#Customer].[Country], [e#Customer].[Fax], [e#Customer].[Phone], [e#Customer].[PostalCode], [e#Customer].[Region]
FROM [Orders] AS [e0]
LEFT JOIN [Customers] AS [e#Customer] ON [e0].[CustomerID] = [e#Customer].[CustomerID]
WHERE [e0].[OrderID] IN (10643, 10692, 10702, 10835, 10952, 11011) AND (@_outer_CustomerID = [e0].[CustomerID])",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT TOP 1 [e#Customer].[CustomerID], [e#Customer].[Address], [e#Customer].[City], [e#Customer].[CompanyName], [e#Customer].[ContactName], [e#Customer].[ContactTitle], [e#Customer].[Country], [e#Customer].[Fax], [e#Customer].[Phone], [e#Customer].[PostalCode], [e#Customer].[Region]
FROM [Orders] AS [e0]
LEFT JOIN [Customers] AS [e#Customer] ON [e0].[CustomerID] = [e#Customer].[CustomerID]
WHERE [e0].[OrderID] IN (10643, 10692, 10702, 10835, 10952, 11011) AND (@_outer_CustomerID = [e0].[CustomerID])",
                //
                @"@_outer_CustomerID='ANTON' (Nullable = false) (Size = 5)

SELECT TOP 1 [e#Customer].[CustomerID], [e#Customer].[Address], [e#Customer].[City], [e#Customer].[CompanyName], [e#Customer].[ContactName], [e#Customer].[ContactTitle], [e#Customer].[Country], [e#Customer].[Fax], [e#Customer].[Phone], [e#Customer].[PostalCode], [e#Customer].[Region]
FROM [Orders] AS [e0]
LEFT JOIN [Customers] AS [e#Customer] ON [e0].[CustomerID] = [e#Customer].[CustomerID]
WHERE [e0].[OrderID] IN (10643, 10692, 10702, 10835, 10952, 11011) AND (@_outer_CustomerID = [e0].[CustomerID])",
                //
                @"@_outer_CustomerID='AROUT' (Nullable = false) (Size = 5)

SELECT TOP 1 [e#Customer].[CustomerID], [e#Customer].[Address], [e#Customer].[City], [e#Customer].[CompanyName], [e#Customer].[ContactName], [e#Customer].[ContactTitle], [e#Customer].[Country], [e#Customer].[Fax], [e#Customer].[Phone], [e#Customer].[PostalCode], [e#Customer].[Region]
FROM [Orders] AS [e0]
LEFT JOIN [Customers] AS [e#Customer] ON [e0].[CustomerID] = [e#Customer].[CustomerID]
WHERE [e0].[OrderID] IN (10643, 10692, 10702, 10835, 10952, 11011) AND (@_outer_CustomerID = [e0].[CustomerID])");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Navigation_fk_based_inside_contains() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] IN ('ALFKI')");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Select_comparison_with_null() : 
            AssertSql(
                @"@__ammunitionType_0='Cartridge'
@__ammunitionType_1='Cartridge'

SELECT [w].[Id], IIf(
    [w].[AmmunitionType] = @__ammunitionType_1,
    True,
    False
) AS [Cartidge]
FROM [Weapon] AS [w]
WHERE [w].[AmmunitionType] = @__ammunitionType_0",
                //
                @"SELECT [w].[Id], IIf(
    [w].[AmmunitionType] IS NULL,
    True,
    False
) AS [Cartidge]
FROM [Weapon] AS [w]
WHERE [w].[AmmunitionType] IS NULL");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Select_length_of_string_property() : 
            AssertSql(
                @"SELECT [w].[Name], CInt(IIf(IsNull(LEN([w].[Name])),0,LEN([w].[Name]))) AS [Length]
FROM [Weapon] AS [w]");



EntityFramework.Jet.FunctionalTests.GearsOfWarQueryJetTest.Entity_equality_empty() : 
            AssertSql(
                @"SELECT [g].[Nickname], [g].[SquadId], [g].[AssignedCityName], [g].[CityOrBirthName], [g].[Discriminator], [g].[FullName], [g].[HasSoulPatch], [g].[LeaderNickname], [g].[LeaderSquadId], [g].[Rank]
FROM [Gear] AS [g]
WHERE [g].[Discriminator] IN ('Officer', 'Gear') AND ([g].[Nickname] IS NULL AND ([g].[SquadId] = 0))");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_alias_generation(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[ProductID], [o].[Discount], [o].[Quantity], [o].[UnitPrice], [o#Order].[OrderID], [o#Order].[CustomerID], [o#Order].[EmployeeID], [o#Order].[OrderDate]
FROM [Order Details] AS [o]
INNER JOIN [Orders] AS [o#Order] ON [o].[OrderID] = [o#Order].[OrderID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_on_join_clause_with_order_by_and_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[City], [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT DISTINCT [c0].[CustomerID], [c0].[City]
    FROM [Customers] AS [c0]
    INNER JOIN [Orders] AS [o0] ON [c0].[CustomerID] = [o0].[CustomerID]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[City], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_on_join_clause_with_order_by_and_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[City], [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT DISTINCT [c0].[CustomerID], [c0].[City]
    FROM [Customers] AS [c0]
    INNER JOIN [Orders] AS [o0] ON [c0].[CustomerID] = [o0].[CustomerID]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[City], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_dependent_already_tracked_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_dependent_already_tracked_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_collection_complex_predicate_not_matching_ins2() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI') AND [c].[CustomerID] NOT IN ('ALFKI', 'ABCDE')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Contains_Column() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (Instr([c].[ContactName], [c].[ContactName]) > 0) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Anonymous_member_distinct_where() : 
            AssertSql(
                @"SELECT [t].[CustomerID]
FROM (
    SELECT DISTINCT [c].[CustomerID]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Contains_Identity() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (Instr([c].[ContactName], [c].[ContactName]) > 0) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_null_coalesce_operator() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY IIf(IsNull([c].[Region]), 'ZZ', [c].[Region])");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_reversed() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE 'London' = [c].[City]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_concat_with_navigation2() : 
            AssertSql(
                @"SELECT ([o#Customer].[City] + ' ') + [o#Customer].[City]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_Where_Count() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_EndsWith_Literal() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE RIGHT([c].[ContactName], LEN('b')) = 'b'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_dependent_already_tracked(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_on_join_clause_with_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT DISTINCT [c0].[CustomerID]
    FROM [Customers] AS [c0]
    INNER JOIN [Orders] AS [o0] ON [c0].[CustomerID] = [o0].[CustomerID]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_on_join_clause_with_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT DISTINCT [c0].[CustomerID]
    FROM [Customers] AS [c0]
    INNER JOIN [Orders] AS [o0] ON [c0].[CustomerID] = [o0].[CustomerID]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Where_Navigation_Equals_Navigation() : 
            AssertSql(
                @"SELECT [o1].[OrderID], [o1].[CustomerID], [o1].[EmployeeID], [o1].[OrderDate], [o2].[OrderID], [o2].[CustomerID], [o2].[EmployeeID], [o2].[OrderDate]
FROM [Orders] AS [o1]
, [Orders] AS [o2]
WHERE ([o1].[CustomerID] = [o2].[CustomerID]) OR ([o1].[CustomerID] IS NULL AND [o2].[CustomerID] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Collection_where_nav_prop_all() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE NOT EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE ([c].[CustomerID] = [o].[CustomerID]) AND (([o].[CustomerID] <> 'ALFKI') OR [o].[CustomerID] IS NULL))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.SelectMany_projection2() : 
            AssertSql(
                @"SELECT [e1].[City], [e2].[Country], [e3].[FirstName]
FROM [Employees] AS [e1]
, [Employees] AS [e2]
, [Employees] AS [e3]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_static_field_access_closure_via_query_cache() : 
            AssertSql(
                @"@__StaticFieldValue_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__StaticFieldValue_0",
                //
                @"@__StaticFieldValue_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__StaticFieldValue_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested_negated3() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE NOT EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A')) AND (([c].[City] <> 'London') OR [c].[City] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_subquery_involving_join_binds_to_correct_table() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE ([o].[OrderID] > 11000) AND [o].[OrderID] IN (
    SELECT [od].[OrderID]
    FROM [Order Details] AS [od]
    INNER JOIN [Products] AS [od#Product] ON [od].[ProductID] = [od#Product].[ProductID]
    WHERE [od#Product].[ProductName] = 'Chai'
)");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_order_by_non_key_with_first_or_default(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CompanyName] DESC, [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID], [c0].[CompanyName]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CompanyName] DESC, [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CompanyName] DESC, [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.GroupJoin_with_nav_projected_in_subquery_when_client_eval() : 
            AssertSql(
                @"SELECT [od0].[OrderID], [od0].[ProductID], [od0].[Discount], [od0].[Quantity], [od0].[UnitPrice], [od#Product0].[ProductID], [od#Product0].[Discontinued], [od#Product0].[ProductName], [od#Product0].[UnitPrice], [od#Product0].[UnitsInStock]
FROM [Order Details] AS [od0]
INNER JOIN [Products] AS [od#Product0] ON [od0].[ProductID] = [od#Product0].[ProductID]",
                //
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [o#Customer0].[CustomerID], [o#Customer0].[Address], [o#Customer0].[City], [o#Customer0].[CompanyName], [o#Customer0].[ContactName], [o#Customer0].[ContactTitle], [o#Customer0].[Country], [o#Customer0].[Fax], [o#Customer0].[Phone], [o#Customer0].[PostalCode], [o#Customer0].[Region]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_collection_navigation_simple() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] LIKE 'A' + '%' AND (LEFT([c0].[CustomerID], LEN('A')) = 'A')
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_kiwi() : 
            AssertSql(
                @"SELECT [k].[Species], [k].[CountryId], [k].[Discriminator], [k].[Name], [k].[EagleId], [k].[IsFlightless], [k].[FoundOn]
FROM [Animal] AS [k]
WHERE ([k].[Discriminator] = 'Kiwi') AND ([k].[CountryId] = 1)");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_bird_first() : 
            AssertSql(
                @"SELECT TOP 1 [b].[Species], [b].[CountryId], [b].[Discriminator], [b].[Name], [b].[EagleId], [b].[IsFlightless], [b].[Group], [b].[FoundOn]
FROM [Animal] AS [b]
WHERE [b].[Discriminator] IN ('Kiwi', 'Eagle') AND ([b].[CountryId] = 1)
ORDER BY [b].[Species]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_filter_reordered(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.FiltersInheritanceJetTest.Can_use_of_type_bird_predicate() : 
            AssertSql(
                @"SELECT [b].[Species], [b].[CountryId], [b].[Discriminator], [b].[Name], [b].[EagleId], [b].[IsFlightless], [b].[Group], [b].[FoundOn]
FROM [Animal] AS [b]
WHERE ([b].[Discriminator] IN ('Kiwi', 'Eagle') AND ([b].[CountryId] = 1)) AND ([b].[CountryId] = 1)
ORDER BY [b].[Species]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Singleton_Navigation_With_Member_Access() : 
            AssertSql(
                @"SELECT [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City] AS [B], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE ([o#Customer].[City] = 'Seattle') AND (([o#Customer].[Phone] <> '555 555 5555') OR [o#Customer].[Phone] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Navigation() : 
            AssertSql(
                @"SELECT [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.FiltersJetTest.Compiled_query() : 
            AssertSql(
                @"@__customerID='BERGS' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = @__customerID",
                //
                @"@__customerID='BLAUS' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = @__customerID");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Join_with_nav_in_orderby_in_subquery_when_client_eval() : 
            AssertSql(
                @"SELECT [od0].[OrderID], [od0].[ProductID], [od0].[Discount], [od0].[Quantity], [od0].[UnitPrice], [od#Product0].[ProductID], [od#Product0].[Discontinued], [od#Product0].[ProductName], [od#Product0].[UnitPrice], [od#Product0].[UnitsInStock]
FROM [Order Details] AS [od0]
INNER JOIN [Products] AS [od#Product0] ON [od0].[ProductID] = [od#Product0].[ProductID]",
                //
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [o#Customer0].[CustomerID], [o#Customer0].[Address], [o#Customer0].[City], [o#Customer0].[CompanyName], [o#Customer0].[ContactName], [o#Customer0].[ContactTitle], [o#Customer0].[Country], [o#Customer0].[Fax], [o#Customer0].[Phone], [o#Customer0].[PostalCode], [o#Customer0].[Region]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Where_Navigation_Contains() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE Instr([o#Customer].[City], 'Sea') > 0");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Where_Navigation() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o#Customer].[City] = 'Seattle'");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Where_nav_prop_group_by() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
INNER JOIN [Orders] AS [od#Order] ON [od].[OrderID] = [od#Order].[OrderID]
WHERE [od#Order].[CustomerID] = 'ALFKI'
ORDER BY [od].[Quantity]");



EntityFramework.Jet.FunctionalTests.FiltersJetTest.Include_query_opt_out() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Join_select_many() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region], [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
, [Employees] AS [e]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_and_collection(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
ORDER BY [o].[OrderID]",
                //
                @"SELECT [o#OrderDetails].[OrderID], [o#OrderDetails].[ProductID], [o#OrderDetails].[Discount], [o#OrderDetails].[Quantity], [o#OrderDetails].[UnitPrice]
FROM [Order Details] AS [o#OrderDetails]
INNER JOIN (
    SELECT DISTINCT [o0].[OrderID]
    FROM [Orders] AS [o0]
    LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]
) AS [t] ON [o#OrderDetails].[OrderID] = [t].[OrderID]
ORDER BY [t].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.LastOrDefault() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactName] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_list_inline() : line() in C:\Develop\ForPlanning\EntityFrameworkCore.Jet\test\EFCore.Jet.FunctionalTests\QueryJetTest.cs:riga 6232
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Project_single_entity_value_subquery_works() : 
            AssertSql(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]
ORDER BY [o].[OrderID]",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]
ORDER BY [o].[OrderID]",
                //
                @"@_outer_CustomerID='ANTON' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]
ORDER BY [o].[OrderID]",
                //
                @"@_outer_CustomerID='AROUT' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]
ORDER BY [o].[OrderID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference_and_collection(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
ORDER BY [o].[OrderID]",
                //
                @"SELECT [o#OrderDetails].[OrderID], [o#OrderDetails].[ProductID], [o#OrderDetails].[Discount], [o#OrderDetails].[Quantity], [o#OrderDetails].[UnitPrice]
FROM [Order Details] AS [o#OrderDetails]
INNER JOIN (
    SELECT DISTINCT [o0].[OrderID]
    FROM [Orders] AS [o0]
    LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]
) AS [t] ON [o#OrderDetails].[OrderID] = [t].[OrderID]
ORDER BY [t].[OrderID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_when_groupby(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[City], [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID], [c0].[City]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[City], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_when_groupby(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[City], [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID], [c0].[City]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[City], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_last_no_orderby(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID] DESC",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CustomerID] DESC
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID] DESC");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_last_no_orderby(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID] DESC",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CustomerID] DESC
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID] DESC");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_order_by_non_key(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[City], [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID], [c0].[City]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[City], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Join_with_nav_in_predicate_in_subquery_when_client_eval() : 
            AssertSql(
                @"SELECT [od0].[OrderID], [od0].[ProductID], [od0].[Discount], [od0].[Quantity], [od0].[UnitPrice], [od#Product0].[ProductID], [od#Product0].[Discontinued], [od#Product0].[ProductName], [od#Product0].[UnitPrice], [od#Product0].[UnitsInStock]
FROM [Order Details] AS [od0]
INNER JOIN [Products] AS [od#Product0] ON [od0].[ProductID] = [od#Product0].[ProductID]",
                //
                @"SELECT [o0].[OrderID], [o0].[CustomerID], [o0].[EmployeeID], [o0].[OrderDate], [o#Customer0].[CustomerID], [o#Customer0].[Address], [o#Customer0].[City], [o#Customer0].[CompanyName], [o#Customer0].[ContactName], [o#Customer0].[ContactTitle], [o#Customer0].[Country], [o#Customer0].[Fax], [o#Customer0].[Phone], [o#Customer0].[PostalCode], [o#Customer0].[Region]
FROM [Orders] AS [o0]
LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_principal_already_tracked_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_principal_already_tracked_as_no_tracking(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Where_Navigation_Multiple_Access() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE ([o#Customer].[City] = 'Seattle') AND (([o#Customer].[Phone] <> '555 555 5555') OR [o#Customer].[Phone] IS NULL)");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_dependent_already_tracked(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_dependent_already_tracked(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE [o].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Collection_select_nav_prop_first_or_default() : 
            AssertSql(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='ANTON' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='AROUT' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='BERGS' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='BLAUS' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='BLONP' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]",
                //
                @"@_outer_CustomerID='BOLID' (Nullable = false) (Size = 5)

SELECT TOP 1 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Orders] AS [o]
WHERE @_outer_CustomerID = [o].[CustomerID]");

Output truncated.

EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested_negated2() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (([c].[City] <> 'London') OR [c].[City] IS NULL) AND NOT EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A'))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Take_subquery_projection() : 
            AssertSql(
                @"@__p_0='2'

SELECT TOP @__p_0 [c].[City]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Average_with_arg_expression() : 
            AssertSql(
                @"SELECT AVG(CDbl(IIf(IsNull([o].[OrderID] + [o].[OrderID]),0,[o].[OrderID] + [o].[OrderID])))
FROM [Orders] AS [o]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_negated_twice() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = True");



EntityFramework.Jet.FunctionalTests.QueryNavigationsJetTest.Select_Where_Navigation_Null_Deep() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
LEFT JOIN [Employees] AS [e#Manager] ON [e].[ReportsTo] = [e#Manager].[EmployeeID]
WHERE [e#Manager].[ReportsTo] IS NULL");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_nested_collection_count_using_DTO() : 
            AssertSql(
                @"SELECT [c].[CustomerID] AS [Id], (
    SELECT COUNT(*)
    FROM [Orders] AS [o]
    WHERE [c].[CustomerID] = [o].[CustomerID]
) AS [Count]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_conditional_order_by(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY IIf(
    [c].[CustomerID] LIKE 'S' + '%' AND (LEFT([c].[CustomerID], LEN('S')) = 'S'),
    1,
    2
), [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID], IIf(
        [c0].[CustomerID] LIKE 'S' + '%' AND (LEFT([c0].[CustomerID], LEN('S')) = 'S'),
        1,
        2
    ) AS [c]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[c], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Anonymous_complex_distinct_result() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM (
    SELECT DISTINCT [c].[CustomerID] + [c].[City] AS [A]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[A] LIKE 'A' + '%' AND (LEFT([t].[A], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_conditional_order_by(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY IIf(
    [c].[CustomerID] LIKE 'S' + '%' AND (LEFT([c].[CustomerID], LEN('S')) = 'S'),
    1,
    2
), [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT [c0].[CustomerID], IIf(
        [c0].[CustomerID] LIKE 'S' + '%' AND (LEFT([c0].[CustomerID], LEN('S')) = 'S'),
        1,
        2
    ) AS [c]
    FROM [Customers] AS [c0]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[c], [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_EndsWith_Column() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (RIGHT([c].[ContactName], LEN([c].[ContactName])) = [c].[ContactName]) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Substring_with_client_eval() : 
            AssertSql(
                @"SELECT TOP 1 [c].[ContactName]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bitwise_and_with_logical_and() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ((IIf(
    [c].[CustomerID] = 'ALFKI',
    True,
    False
) BAND IIf(
    [c].[CustomerID] = 'ANATR',
    True,
    False
)) = True) AND ([c].[CustomerID] = 'ANTON')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_null_coalesce_operator() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[CompanyName], IIf(IsNull([c].[Region]), 'ZZ', [c].[Region]) AS [Region]
FROM [Customers] AS [c]
ORDER BY [Region]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Projection_null_coalesce_operator() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[CompanyName], IIf(IsNull([c].[Region]), 'ZZ', [c].[Region]) AS [Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_parameter() : 
            AssertSql(
                @"@__prm_0='True'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE @__prm_0 = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Null_conditional_deep() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE CInt(IIf(IsNull(LEN([c].[CustomerID])),0,LEN([c].[CustomerID]))) = 5");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_not_in_optimization4() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region], [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Customers] AS [c]
, [Employees] AS [e]
WHERE [c].[City] NOT IN ('London', 'Berlin', 'Seattle', 'Lisboa')");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_principal_already_tracked(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'",
                //
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID]
    FROM [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
    ORDER BY [c0].[CustomerID]
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_concat_with_navigation1() : 
            AssertSql(
                @"SELECT ([o].[CustomerID] + ' ') + [o#Customer].[City]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.DTO_member_distinct_where() : 
            AssertSql(
                @"SELECT [t].[Property]
FROM (
    SELECT DISTINCT [c].[CustomerID] AS [Property]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[Property] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Queryable_simple_anonymous_subquery() : 
            AssertSql(
                @"@__p_0='91'

SELECT TOP @__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_with_skip(Boolean useString) : 
            AssertSql(
                @"@__p_0='80'

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactName], [c].[CustomerID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_with_skip(Boolean useString) : 
            AssertSql(
                @"@__p_0='80'

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactName], [c].[CustomerID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Sum_on_float_column_in_subquery() : 
            AssertSql(
                @"SELECT [o].[OrderID], (
    SELECT CSng(IIf(IsNull(SUM([od].[Discount])),0,SUM([od].[Discount])))
    FROM [Order Details] AS [od]
    WHERE [o].[OrderID] = [od].[OrderID]
) AS [Sum]
FROM [Orders] AS [o]
WHERE [o].[OrderID] < 10300");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_nested_collection_multi_level3() : 
            AssertSql(
                @"SELECT (
    SELECT TOP 1 [o].[OrderDate]
    FROM [Orders] AS [o]
    WHERE ([o].[OrderID] < 10500) AND ([c].[CustomerID] = [o].[CustomerID])
) AS [OrderDates]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.SelectMany_Count() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Customers] AS [c]
, [Orders] AS [o]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_shadow_subquery_FirstOrDefault() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[Title] = (
    SELECT TOP 1 [e2].[Title]
    FROM [Employees] AS [e2]
    ORDER BY [e2].[Title]
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Join_Where_Count() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_multi_level_reference_and_collection_predicate(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 2 [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
WHERE [o].[OrderID] = 10248
ORDER BY [o#Customer].[CustomerID]",
                //
                @"SELECT [o#Customer#Orders].[OrderID], [o#Customer#Orders].[CustomerID], [o#Customer#Orders].[EmployeeID], [o#Customer#Orders].[OrderDate]
FROM [Orders] AS [o#Customer#Orders]
INNER JOIN (
    SELECT DISTINCT [t].*
    FROM (
        SELECT TOP 1 [o#Customer0].[CustomerID]
        FROM [Orders] AS [o0]
        LEFT JOIN [Customers] AS [o#Customer0] ON [o0].[CustomerID] = [o#Customer0].[CustomerID]
        WHERE [o0].[OrderID] = 10248
        ORDER BY [o#Customer0].[CustomerID]
    ) AS [t]
) AS [t0] ON [o#Customer#Orders].[CustomerID] = [t0].[CustomerID]
ORDER BY [t0].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_false() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_reference(Boolean useString) : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate], [o#Customer].[CustomerID], [o#Customer].[Address], [o#Customer].[City], [o#Customer].[CompanyName], [o#Customer].[ContactName], [o#Customer].[ContactTitle], [o#Customer].[Country], [o#Customer].[Fax], [o#Customer].[Phone], [o#Customer].[PostalCode], [o#Customer].[Region]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_with_last(Boolean useString) : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CompanyName] DESC, [c].[CustomerID] DESC",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT TOP 1 [c0].[CustomerID], [c0].[CompanyName]
    FROM [Customers] AS [c0]
    ORDER BY [c0].[CompanyName] DESC, [c0].[CustomerID] DESC
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CompanyName] DESC, [t].[CustomerID] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.DTO_member_distinct_result() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM (
    SELECT DISTINCT [c].[CustomerID] AS [Property]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[Property] LIKE 'A' + '%' AND (LEFT([t].[Property], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_where_skip_take_projection(Boolean useString) : 
            AssertSql(
                @"@__p_0='1'
@__p_1='2'

SELECT TOP @__p_1+@__p_0 [od#Order].[CustomerID]
FROM [Order Details] AS [od]
INNER JOIN [Orders] AS [od#Order] ON [od].[OrderID] = [od#Order].[OrderID]
WHERE [od].[Quantity] = 10
ORDER BY [od].[OrderID], [od].[ProductID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_where_skip_take_projection(Boolean useString) : 
            AssertSql(
                @"@__p_0='1'
@__p_1='2'

SELECT TOP @__p_1+@__p_0 [od#Order].[CustomerID]
FROM [Order Details] AS [od]
INNER JOIN [Orders] AS [od#Order] ON [od].[OrderID] = [od#Order].[OrderID]
WHERE [od].[Quantity] = 10
ORDER BY [od].[OrderID], [od].[ProductID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_equals_using_int_overload_on_mismatched_types() : 
            AssertSql(
                @"@__shortPrm_0='1'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[EmployeeID] = @__shortPrm_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_EndsWith_Identity() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (RIGHT([c].[ContactName], LEN([c].[ContactName])) = [c].[ContactName]) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_de_morgan_and_optimizated() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE ([p].[Discontinued] = False) OR ([p].[ProductID] >= 20)");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_on_additional_from_clause_with_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c1]
, [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT DISTINCT [c0].[CustomerID]
    FROM [Customers] AS [c10]
    , [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.IncludeJetTest.Include_collection_on_additional_from_clause_with_filter(Boolean useString) : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c1]
, [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]",
                //
                @"SELECT [c#Orders].[OrderID], [c#Orders].[CustomerID], [c#Orders].[EmployeeID], [c#Orders].[OrderDate]
FROM [Orders] AS [c#Orders]
INNER JOIN (
    SELECT DISTINCT [c0].[CustomerID]
    FROM [Customers] AS [c10]
    , [Customers] AS [c0]
    WHERE [c0].[CustomerID] = 'ALFKI'
) AS [t] ON [c#Orders].[CustomerID] = [t].[CustomerID]
ORDER BY [t].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_expression_long_to_string() : 
            AssertSql(
                @"SELECT Str([o].[OrderID]) AS [ShipName]
FROM [Orders] AS [o]
WHERE [o].[OrderDate] IS NOT NULL");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Average_with_no_arg() : 
            AssertSql(
                @"SELECT AVG(CDbl(IIf(IsNull([o].[OrderID]),0,[o].[OrderID])))
FROM [Orders] AS [o]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Distinct_Take() : 
            AssertSql(
                @"@__p_0='5'

SELECT TOP @__p_0 [t].[OrderID], [t].[CustomerID], [t].[EmployeeID], [t].[OrderDate]
FROM (
    SELECT DISTINCT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
    FROM [Orders] AS [o]
) AS [t]
ORDER BY [t].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_collection_sql_injection() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ALFKI', 'ABC'')); GO; DROP TABLE Orders; GO; --', 'ALFKI', 'ABCDE')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested3() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A')) AND (([c].[City] <> 'London') OR [c].[City] IS NULL)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.SelectMany_projection1() : 
            AssertSql(
                @"SELECT [e1].[City], [e2].[Country]
FROM [Employees] AS [e1]
, [Employees] AS [e2]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_EndsWith_MethodCall() : 
            AssertSql(
                @"@__LocalMethod2_0='m' (Nullable = false) (Size = 1)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (RIGHT([c].[ContactName], LEN(@__LocalMethod2_0)) = @__LocalMethod2_0) OR (@__LocalMethod2_0 = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_closure_via_query_cache() : 
            AssertSql(
                @"@__city_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_0",
                //
                @"@__city_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_expression_invoke() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Anonymous_member_distinct_result() : 
            AssertSql(
                @"SELECT COUNT(*)
FROM (
    SELECT DISTINCT [c].[CustomerID]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[CustomerID] LIKE 'A' + '%' AND (LEFT([t].[CustomerID], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Join_Customers_Orders_Projection_With_String_Concat_Skip_Take() : 
            AssertSql(
                @"@__p_0='10'
@__p_1='5'

SELECT TOP @__p_1+@__p_0 ([c].[ContactName] + ' ') + [c].[ContactTitle] AS [Contact], [o].[OrderID]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
ORDER BY [o].[OrderID]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_select_many_or3() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region], [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Customers] AS [c]
, [Employees] AS [e]
WHERE [c].[City] IN ('London', 'Berlin', 'Seattle')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_member_compared_to_binary_expression() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = IIf(
    [p].[ProductID] > 50,
    True,
    False
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Null_conditional_simple() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_comparison_to_nullable_bool() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE RIGHT([c].[CustomerID], LEN('KI')) = 'KI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bitwise_or_with_logical_or() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ((IIf(
    [c].[CustomerID] = 'ALFKI',
    True,
    False
) BOR IIf(
    [c].[CustomerID] = 'ANATR',
    True,
    False
)) = True) OR ([c].[CustomerID] = 'ANTON')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_subquery_and_local_array_closure() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Customers] AS [c1]
    WHERE [c1].[City] IN ('London', 'Buenos Aires') AND ([c1].[CustomerID] = [c].[CustomerID]))",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Customers] AS [c1]
    WHERE [c1].[City] IN ('London') AND ([c1].[CustomerID] = [c].[CustomerID]))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_many_cross_join_same_collection() : 
            AssertSql(
                @"SELECT [c0].[CustomerID], [c0].[Address], [c0].[City], [c0].[CompanyName], [c0].[ContactName], [c0].[ContactTitle], [c0].[Country], [c0].[Fax], [c0].[Phone], [c0].[PostalCode], [c0].[Region]
FROM [Customers] AS [c]
, [Customers] AS [c0]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Average_with_arg() : 
            AssertSql(
                @"SELECT AVG(CDbl(IIf(IsNull([o].[OrderID]),0,[o].[OrderID])))
FROM [Orders] AS [o]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_bitwise_or_with_logical_or() : 
            AssertSql(
                @"SELECT [c].[CustomerID], IIf(
    ((IIf(
        [c].[CustomerID] = 'ALFKI',
        True,
        False
    ) BOR IIf(
        [c].[CustomerID] = 'ANATR',
        True,
        False
    )) = True) OR ([c].[CustomerID] = 'ANTON'),
    True,
    False
) AS [Value]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_LastOrDefault() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = 'London'
ORDER BY [c].[ContactName] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_Contains_Literal() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE Instr([c].[ContactName], 'M') > 0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_equals_on_mismatched_types_nullable_int_long() : 
            AssertSql(
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE False = True",
                //
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_ternary_boolean_condition_false() : 
            AssertSql(
                @"@__flag_0='False'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE ((@__flag_0 = True) AND ([p].[UnitsInStock] >= 20)) OR ((@__flag_0 <> True) AND ([p].[UnitsInStock] < 20))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Average_with_division_on_decimal_no_significant_digits() : 
            AssertSql(
                @"SELECT AVG(CCur(IIf(IsNull([od].[Quantity] / 2.0),0,[od].[Quantity] / 2.0)))
FROM [Order Details] AS [od]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_concat_string_int_comparison1() : 
            AssertSql(
                @"@__i_0='10'

SELECT [c].[CustomerID]
FROM [Customers] AS [c]
WHERE ([c].[CustomerID] + (@__i_0&"""")) = [c].[CompanyName]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Single_Predicate() : 
            AssertSql(
                @"SELECT TOP 2 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Take_simple_parameterized() : 
            AssertSql(
                @"@__p_0='10'

SELECT TOP @__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_collection_complex_predicate_or() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI', 'ALFKI', 'ABCDE')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_select_many_and() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region], [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Customers] AS [c]
, [Employees] AS [e]
WHERE (([c].[City] = 'London') AND ([c].[Country] = 'UK')) AND (([e].[City] = 'London') AND ([e].[Country] = 'UK'))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_with_multiple_conditions_still_uses_exists() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ([c].[City] = 'London') AND EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE ([o].[EmployeeID] = 1) AND ([c].[CustomerID] = [o].[CustomerID]))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Average_on_float_column_in_subquery() : 
            AssertSql(
                @"SELECT [o].[OrderID]
FROM [Orders] AS [o]
WHERE [o].[OrderID] < 10300",
                //
                @"@_outer_OrderID='10248'

SELECT CSng(IIf(IsNull(AVG(CSng(IIf(IsNull([od0].[Discount]),0,[od0].[Discount])))),0,AVG(CSng(IIf(IsNull([od0].[Discount]),0,[od0].[Discount])))))
FROM [Order Details] AS [od0]
WHERE @_outer_OrderID = [od0].[OrderID]",
                //
                @"@_outer_OrderID='10249'

SELECT CSng(IIf(IsNull(AVG(CSng(IIf(IsNull([od0].[Discount]),0,[od0].[Discount])))),0,AVG(CSng(IIf(IsNull([od0].[Discount]),0,[od0].[Discount])))))
FROM [Order Details] AS [od0]
WHERE @_outer_OrderID = [od0].[OrderID]",
                //
                @"@_outer_OrderID='10250'

SELECT CSng(IIf(IsNull(AVG(CSng(IIf(IsNull([od0].[Discount]),0,[od0].[Discount])))),0,AVG(CSng(IIf(IsNull([od0].[Discount]),0,[od0].[Discount])))))
FROM [Order Details] AS [od0]
WHERE @_outer_OrderID = [od0].[OrderID]",
                //
                @"@_outer_OrderID='10251'

SELECT CSng(IIf(IsNull(AVG(CSng(IIf(IsNull([od0].[Discount]),0,[od0].[Discount])))),0,AVG(CSng(IIf(IsNull([od0].[Discount]),0,[od0].[Discount])))))
FROM [Order Details] AS [od0]
WHERE @_outer_OrderID = [od0].[OrderID]",
                //
                @"@_outer_OrderID='10252'

SELECT CSng(IIf(IsNull(AVG(CSng(IIf(IsNull([od0].[Discount]),0,[od0].[Discount])))),0,AVG(CSng(IIf(IsNull([od0].[Discount]),0,[od0].[Discount])))))
FROM [Order Details] AS [od0]
WHERE @_outer_OrderID = [od0].[OrderID]",
                //
                @"@_outer_OrderID='10253'

SELECT CSng(IIf(IsNull(AVG(CSng(IIf(IsNull([od0].[Discount]),0,[od0].[Discount])))),0,AVG(CSng(IIf(IsNull([od0].[Discount]),0,[od0].[Discount])))))
FROM [Order Details] AS [od0]
WHERE @_outer_OrderID = [od0].[OrderID]",
                //
                @"@_outer_OrderID='10254'

SELECT CSng(IIf(IsNull(AVG(CSng(IIf(IsNull([od0].[Discount]),0,[od0].[Discount])))),0,AVG(CSng(IIf(IsNull([od0].[Discount]),0,[od0].[Discount])))))
FROM [Order Details] AS [od0]
WHERE @_outer_OrderID = [od0].[OrderID]",
                //
                @"@_outer_OrderID='10255'

SELECT CSng(IIf(IsNull(AVG(CSng(IIf(IsNull([od0].[Discount]),0,[od0].[Discount])))),0,AVG(CSng(IIf(IsNull([od0].[Discount]),0,[od0].[Discount])))))
FROM [Order Details] AS [od0]
WHERE @_outer_OrderID = [od0].[OrderID]");

Output truncated.

EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_expression_other_to_string() : 
            AssertSql(
                @"SELECT Str([o].[OrderDate]) AS [ShipName]
FROM [Orders] AS [o]
WHERE [o].[OrderDate] IS NOT NULL");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Average_on_float_column() : 
            AssertSql(
                @"SELECT CSng(IIf(IsNull(AVG(CSng(IIf(IsNull([od].[Discount]),0,[od].[Discount])))),0,AVG(CSng(IIf(IsNull([od].[Discount]),0,[od].[Discount])))))
FROM [Order Details] AS [od]
WHERE [od].[ProductID] = 1");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_join_select() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
INNER JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [c].[CustomerID] = 'ALFKI'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_math_sin() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
WHERE ([od].[OrderID] = 11077) AND (SIN([od].[Discount]) > 0E0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_concat_string_int_comparison2() : 
            AssertSql(
                @"@__i_0='10'

SELECT [c].[CustomerID]
FROM [Customers] AS [c]
WHERE ((@__i_0&"""") + [c].[CustomerID]) = [c].[CompanyName]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_skip_take() : 
            AssertSql(
                @"@__p_0='5'
@__p_1='8'

SELECT TOP @__p_1+@__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactTitle], [c].[ContactName]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_concat_string_int_comparison3() : 
            AssertSql(
                @"@__j_1='21'
@__i_0='10'

SELECT [c].[CustomerID]
FROM [Customers] AS [c]
WHERE ((((@__i_0 + 20&"""") + [c].[CustomerID]) + (@__j_1&"""")) + (42&"""")) = [c].[CompanyName]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_in_optimization_multiple() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region], [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Customers] AS [c]
, [Employees] AS [e]
WHERE ([c].[City] IN ('London', 'Berlin') OR ([c].[CustomerID] = 'ALFKI')) OR ([c].[CustomerID] = 'ABCDE')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_nested_collection_multi_level6() : 
            AssertSql(
                @"SELECT (
    SELECT TOP 1 (
        SELECT TOP 1 [od].[ProductID]
        FROM [Order Details] AS [od]
        WHERE ([od].[OrderID] <> CInt(IIf(IsNull(LEN([c].[CustomerID])),0,LEN([c].[CustomerID])))) AND ([o].[OrderID] = [od].[OrderID])
    )
    FROM [Orders] AS [o]
    WHERE ([o].[OrderID] < 10500) AND ([c].[CustomerID] = [o].[CustomerID])
) AS [Order]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_negated_boolean_expression_compared_to_another_negated_boolean_expression() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE IIf(
    [p].[ProductID] > 50,
    True,
    False
) = IIf(
    [p].[ProductID] > 20,
    True,
    False
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.String_StartsWith_Identity() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ([c].[ContactName] LIKE [c].[ContactName] + '%' AND (LEFT([c].[ContactName], LEN([c].[ContactName])) = [c].[ContactName])) OR ([c].[ContactName] = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OfType_Select() : 
            AssertSql(
                @"SELECT TOP 1 [o#Customer].[City]
FROM [Orders] AS [o]
LEFT JOIN [Customers] AS [o#Customer] ON [o].[CustomerID] = [o#Customer].[CustomerID]
ORDER BY [o].[OrderID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.DTO_complex_distinct_where() : 
            AssertSql(
                @"SELECT [t].[Property]
FROM (
    SELECT DISTINCT [c].[CustomerID] + [c].[City] AS [Property]
    FROM [Customers] AS [c]
) AS [t]
WHERE [t].[Property] = 'ALFKIBerlin'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_select_many_or_with_parameter() : 
            AssertSql(
                @"@__lisboa_1='Lisboa' (Nullable = false) (Size = 6)
@__london_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region], [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Customers] AS [c]
, [Employees] AS [e]
WHERE [c].[City] IN (@__london_0, 'Berlin', 'Seattle', @__lisboa_1)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.SelectMany_entity_deep() : 
            AssertSql(
                @"SELECT [e1].[EmployeeID], [e1].[City], [e1].[Country], [e1].[FirstName], [e1].[ReportsTo], [e1].[Title], [e2].[EmployeeID], [e2].[City], [e2].[Country], [e2].[FirstName], [e2].[ReportsTo], [e2].[Title], [e3].[EmployeeID], [e3].[City], [e3].[Country], [e3].[FirstName], [e3].[ReportsTo], [e3].[Title], [e4].[EmployeeID], [e4].[City], [e4].[Country], [e4].[FirstName], [e4].[ReportsTo], [e4].[Title]
FROM [Employees] AS [e1]
, [Employees] AS [e2]
, [Employees] AS [e3]
, [Employees] AS [e4]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_ternary_boolean_condition_true() : 
            AssertSql(
                @"@__flag_0='True'

SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE ((@__flag_0 = True) AND ([p].[UnitsInStock] >= 20)) OR ((@__flag_0 <> True) AND ([p].[UnitsInStock] < 20))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_collection_complex_predicate_not_matching_ins1() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ALFKI', 'ABCDE') OR [c].[CustomerID] NOT IN ('ABCDE', 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bool_client_side_negated() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE [p].[Discontinued] = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_nested_collection_multi_level() : 
            AssertSql(
                @"SELECT [c].[CustomerID]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')",
                //
                @"@_outer_CustomerID='ALFKI' (Nullable = false) (Size = 5)

SELECT TOP 3 [o].[OrderDate] AS [Date]
FROM [Orders] AS [o]
WHERE ([o].[OrderID] < 10500) AND (@_outer_CustomerID = [o].[CustomerID])",
                //
                @"@_outer_CustomerID='ANATR' (Nullable = false) (Size = 5)

SELECT TOP 3 [o].[OrderDate] AS [Date]
FROM [Orders] AS [o]
WHERE ([o].[OrderID] < 10500) AND (@_outer_CustomerID = [o].[CustomerID])",
                //
                @"@_outer_CustomerID='ANTON' (Nullable = false) (Size = 5)

SELECT TOP 3 [o].[OrderDate] AS [Date]
FROM [Orders] AS [o]
WHERE ([o].[OrderID] < 10500) AND (@_outer_CustomerID = [o].[CustomerID])",
                //
                @"@_outer_CustomerID='AROUT' (Nullable = false) (Size = 5)

SELECT TOP 3 [o].[OrderDate] AS [Date]
FROM [Orders] AS [o]
WHERE ([o].[OrderID] < 10500) AND (@_outer_CustomerID = [o].[CustomerID])");



EntityFramework.Jet.FunctionalTests.QueryJetTest.OrderBy_SelectMany() : 
            AssertSql(
                @"SELECT [c].[ContactName], [t].[OrderID]
FROM [Customers] AS [c]
, (
    SELECT TOP 3 [o].*
    FROM [Orders] AS [o]
    ORDER BY [o].[OrderID]
) AS [t]
WHERE [c].[CustomerID] = [t].[CustomerID]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.IsNullOrEmpty_in_projection() : 
            AssertSql(
                @"SELECT [c].[CustomerID] AS [Id], IIf(
    [c].[Region] IS NULL OR ([c].[Region] = ''),
    True,
    False
) AS [Value]
FROM [Customers] AS [c]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_shadow_projection() : 
            AssertSql(
                @"SELECT [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[Title] = 'Sales Representative'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_simple_closure_via_query_cache_nullable_type() : 
            AssertSql(
                @"@__reportsTo_0='2'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[ReportsTo] = @__reportsTo_0",
                //
                @"@__reportsTo_0='5'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[ReportsTo] = @__reportsTo_0",
                //
                @"SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[ReportsTo] IS NULL");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_nested_field_access_closure_via_query_cache() : 
            AssertSql(
                @"@__city_Nested_InstanceFieldValue_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_Nested_InstanceFieldValue_0",
                //
                @"@__city_Nested_InstanceFieldValue_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__city_Nested_InstanceFieldValue_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.GroupJoin_DefaultIfEmpty_Where() : 
            AssertSql(
                @"SELECT [o].[OrderID], [o].[CustomerID], [o].[EmployeeID], [o].[OrderDate]
FROM [Customers] AS [c]
LEFT JOIN [Orders] AS [o] ON [c].[CustomerID] = [o].[CustomerID]
WHERE [o].[OrderID] IS NOT NULL AND ([o].[CustomerID] = 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_constant_is_null() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE False = True");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Any_nested_negated() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE NOT EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE [o].[CustomerID] LIKE 'A' + '%' AND (LEFT([o].[CustomerID], LEN('A')) = 'A'))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Last() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactName] DESC");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_method_call_nullable_type_reverse_closure_via_query_cache() : 
            AssertSql(
                @"@__city_NullableInt_0='1'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[EmployeeID] > @__city_NullableInt_0",
                //
                @"@__city_NullableInt_0='5'

SELECT [e].[EmployeeID], [e].[City], [e].[Country], [e].[FirstName], [e].[ReportsTo], [e].[Title]
FROM [Employees] AS [e]
WHERE [e].[EmployeeID] > @__city_NullableInt_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_subquery_closure_via_query_cache() : 
            AssertSql(
                @"@__customerID_0='ALFKI' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE ([o].[CustomerID] = @__customerID_0) AND ([o].[CustomerID] = [c].[CustomerID]))",
                //
                @"@__customerID_0='ANATR' (Nullable = false) (Size = 5)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE EXISTS (
    SELECT 1
    FROM [Orders] AS [o]
    WHERE ([o].[CustomerID] = @__customerID_0) AND ([o].[CustomerID] = [c].[CustomerID]))");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_math_exp() : 
            AssertSql(
                @"SELECT [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
WHERE ([od].[OrderID] = 11077) AND (EXP([od].[Discount]) > 1E0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Skip_Take() : 
            AssertSql(
                @"@__p_0='5'
@__p_1='10'

SELECT TOP @__p_1+@__p_0 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
ORDER BY [c].[ContactName]
 SKIP @__p_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_de_morgan_or_optimizated() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE ([p].[Discontinued] = False) AND ([p].[ProductID] >= 20)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_bitwise_and() : 
            AssertSql(
                @"SELECT [c].[CustomerID], IIf(
    [c].[CustomerID] = 'ALFKI',
    True,
    False
) BAND IIf(
    [c].[CustomerID] = 'ANATR',
    True,
    False
) AS [Value]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_query_composition() : 
            AssertSql(
                @"SELECT [e1].[EmployeeID], [e1].[City], [e1].[Country], [e1].[FirstName], [e1].[ReportsTo], [e1].[Title]
FROM [Employees] AS [e1]
WHERE [e1].[FirstName] = (
    SELECT TOP 1 [e].[FirstName]
    FROM [Employees] AS [e]
    ORDER BY [e].[EmployeeID]
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_scalar_primitive_after_take() : 
            AssertSql(
                @"@__p_0='9'

SELECT TOP @__p_0 [e].[EmployeeID]
FROM [Employees] AS [e]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.FirstOrDefault_inside_subquery_gets_server_evaluated() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ([c].[CustomerID] = 'ALFKI') AND ((
    SELECT TOP 1 [o].[CustomerID]
    FROM [Orders] AS [o]
    WHERE ([o].[CustomerID] = 'ALFKI') AND ([c].[CustomerID] = [o].[CustomerID])
) = 'ALFKI')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_orderby_select_many() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
, [Orders] AS [o]
WHERE [c].[CustomerID] = 'ALFKI'
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Average_with_coalesce() : 
            AssertSql(
                @"SELECT AVG(CCur(IIf(IsNull(IIf(IsNull([p].[UnitPrice]), 0.0, [p].[UnitPrice])),0,IIf(IsNull([p].[UnitPrice]), 0.0, [p].[UnitPrice]))))
FROM [Products] AS [p]
WHERE [p].[ProductID] < 40");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_bitwise_and_with_logical_or() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE ((IIf(
    [c].[CustomerID] = 'ALFKI',
    True,
    False
) BAND IIf(
    [c].[CustomerID] = 'ANATR',
    True,
    False
)) = True) OR ([c].[CustomerID] = 'ANTON')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.IsNullOrWhiteSpace_in_predicate() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[Region] IS NULL OR (LTRIM(RTRIM([c].[Region])) = '')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Contains_with_local_array_closure() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE', 'ALFKI')",
                //
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] IN ('ABCDE')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Subquery_is_null_translated_correctly() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE (
    SELECT TOP 1 [o].[CustomerID]
    FROM [Orders] AS [o]
    WHERE [c].[CustomerID] = [o].[CustomerID]
    ORDER BY [o].[OrderID] DESC
) IS NULL");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Average_with_division_on_decimal() : 
            AssertSql(
                @"SELECT AVG(CCur(IIf(IsNull([od].[Quantity] / 2.09),0,[od].[Quantity] / 2.09)))
FROM [Order Details] AS [od]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_nested_collection_multi_level4() : 
            AssertSql(
                @"SELECT (
    SELECT TOP 1 (
        SELECT COUNT(*)
        FROM [Order Details] AS [od]
        WHERE ([od].[OrderID] > 10) AND ([o].[OrderID] = [od].[OrderID])
    )
    FROM [Orders] AS [o]
    WHERE ([o].[OrderID] < 10500) AND ([c].[CustomerID] = [o].[CustomerID])
) AS [Order]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] LIKE 'A' + '%' AND (LEFT([c].[CustomerID], LEN('A')) = 'A')");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Handle_materialization_properly_when_more_than_two_query_sources_are_involved() : 
            AssertSql(
                @"SELECT TOP 1 [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
, [Orders] AS [o]
, [Employees] AS [e]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Query_expression_with_to_string_and_contains() : 
            AssertSql(
                @"SELECT [o].[CustomerID]
FROM [Orders] AS [o]
WHERE [o].[OrderDate] IS NOT NULL AND (Instr(Str([o].[EmployeeID]), '10') > 0)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_bitwise_or() : 
            AssertSql(
                @"SELECT [c].[CustomerID], IIf(
    [c].[CustomerID] = 'ALFKI',
    True,
    False
) BOR IIf(
    [c].[CustomerID] = 'ANATR',
    True,
    False
) AS [Value]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Take_simple_projection() : 
            AssertSql(
                @"@__p_0='10'

SELECT TOP @__p_0 [c].[City]
FROM [Customers] AS [c]
ORDER BY [c].[CustomerID]");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_static_property_access_closure_via_query_cache() : 
            AssertSql(
                @"@__StaticPropertyValue_0='London' (Nullable = false) (Size = 6)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__StaticPropertyValue_0",
                //
                @"@__StaticPropertyValue_0='Seattle' (Nullable = false) (Size = 7)

SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[City] = @__StaticPropertyValue_0");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_subquery_on_bool() : 
            AssertSql(
                @"SELECT [p].[ProductID], [p].[Discontinued], [p].[ProductName], [p].[UnitPrice], [p].[UnitsInStock]
FROM [Products] AS [p]
WHERE 'Chai' IN (
    SELECT [p2].[ProductName]
    FROM [Products] AS [p2]
)");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Select_Where_Subquery_Deep_First() : 
            AssertSql(
                @"@__p_0='2'

SELECT TOP @__p_0 [od].[OrderID], [od].[ProductID], [od].[Discount], [od].[Quantity], [od].[UnitPrice]
FROM [Order Details] AS [od]
WHERE (
    SELECT TOP 1 (
        SELECT TOP 1 [c].[City]
        FROM [Customers] AS [c]
        WHERE [o].[CustomerID] = [c].[CustomerID]
    )
    FROM [Orders] AS [o]
    WHERE [od].[OrderID] = [o].[OrderID]
) = 'Seattle'");



EntityFramework.Jet.FunctionalTests.QueryJetTest.Where_client_deep_inside_predicate_and_server_top_level() : 
            AssertSql(
                @"SELECT [c].[CustomerID], [c].[Address], [c].[City], [c].[CompanyName], [c].[ContactName], [c].[ContactTitle], [c].[Country], [c].[Fax], [c].[Phone], [c].[PostalCode], [c].[Region]
FROM [Customers] AS [c]
WHERE [c].[CustomerID] <> 'ALFKI'");



