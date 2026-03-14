using DirectoryService.Domain.Positions;

namespace DirectoryService.Domain.Departments;

public record class DepartmentPosition(DepartmentId DepartmentId,  PositionId PositionId);