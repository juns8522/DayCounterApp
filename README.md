# DayCounterApp
This application calculates the number of weekdays between two dates. Assume weekdays are Monday to Friday. The returned count should not include from date or to date.
Examples:
* Thu 7/8/2014 to Mon 11/8/2014 should return 1
* Wed 13/8/2014 to Thu 21/8/2014 should return 5 

There are three types of holidays:
1. Always on the same day even if it is a weekend (like Anzac Day 25 April every year).
2. On the same day as far as it is not a weekend (like New Year 1st of every year unless it
is a weekend, then the holiday would be next Monday).
3. Certain occurrence on a certain day in a month (like Queen’s Birthday on the second
Monday in June every year). 

This consists of 3 projects:
1. DayCounterApp.Api: web API with ASP.NET Core 
2. DayCounterApp: React App
3. DayCounterApp.Tests: nUnit Test
