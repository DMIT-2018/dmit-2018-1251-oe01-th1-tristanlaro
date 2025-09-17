<Query Kind="Statements">
  <Connection>
    <ID>0744cc78-570d-4bdf-8d79-dd03ee9ba5de</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>StartTed-2025-Sept</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

//Question 1
ClubActivities.Where(x => x.CampusVenueID != 1 && x.Name != "BTech Club Meeting" && x.StartDate.Value > new DateTime(2025, 1, 1))
.Select(x => new
{
	StartDate = x.StartDate,
	Location = x.CampusVenue.Location,
	Club = x.Club.ClubName,
Activity = x.Name
})
.OrderBy(x => x.StartDate)
.Dump();
// Question 2
