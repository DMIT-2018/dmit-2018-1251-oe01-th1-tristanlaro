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
ProgramCourses
.GroupBy(x => new
{
	x.Program.ProgramName, x.Program.SchoolCode,
} )
.Where(x => x.Count(x => x.Required) >= 22)
.Select(x => new{
School = x.Key.SchoolCode == "SAMIT" ? "School of Advance Media and IT":
				x.Key.SchoolCode == "SEET" ? "School of Electrical Engineering Technology":
				"unknown",
Program = x.Key.ProgramName,
RequiredCourseCount = x.Count(x => x.Required),
OptionalCourseCount = x.Count(x => x.Required == false)

})
.OrderBy(x => x.Program)
.Dump();
//Question 3
Students.Where(x => x.StudentPayments.Count == 0 && x.CountryCode != "CA")
.OrderBy(x => x.LastName)
.Select(x => new { 
	StudentNumber = x.StudentNumber,
	CountryName = x.Countries.CountryName,
	FullName = x.FirstName + " " + x.LastName
})
.Dump();
//Question 4
Employees.Where(x => x.PositionID == 4 && x.ReleaseDate.Value == null && x.ClassOfferings.Any( )  )
.OrderByDescending(x => x.ClassOfferings.Count() )
.ThenBy(x =>x.LastName )
.Select(x => new {
	ProgramName = x.Program.ProgramName,
	Fullname = x.FirstName + " " + x.LastName,
	WorkLoad = x.ClassOfferings.Count() > 24 ? "High":
					 x.ClassOfferings.Count() > 8 ? "Med":
					 "Low"
					
}).Dump();
// Question 5
Clubs.Select(x => new {
Supervisor = x.Employee == null ? "unknown":
					x.Employee.FirstName + " " + x.Employee.LastName,
 Club = x.ClubName,
 MemberCount = x.ClubMembers.Count(),
 Activites = x.ClubActivities.Count() == 0 ? "None Scheduled":
 				x.ClubActivities.Count().ToString(),
})
.OrderByDescending(x => x.MemberCount)
.Dump();