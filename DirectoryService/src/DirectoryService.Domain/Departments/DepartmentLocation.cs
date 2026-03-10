using DirectoryService.Domain.Locations;

namespace DirectoryService.Domain.Departments;

public record class DepartmentLocation(DepartmentId DepartmentId,  LocationId LocationId);