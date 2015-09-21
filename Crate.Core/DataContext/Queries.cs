
namespace Crate.Core.DataContext
{
    public class Queries
    {
        public const string SelectInstances = "SELECT ObjectData FROM Instances WHERE ObjectId = @ObjectId and RepositoryId = @RepositoryId";
        public const string SelectInstTypeId = "Select Id from InstanceTypes where Name = @Name and RepositoryId = @RepositoryId";
        public const string SelectProperties = "Select Properties from InstanceTypes where name = @ObjectName AND RepositoryId = @RepositoryId";
        public const string SelectRepositoryId = "SELECT Id FROM Repositories where Name = @Name";
        public const string InsertToInstance = "INSERT INTO Instances (GuidID, ObjectId, ObjectData, RepositoryId) " +
                                           "VALUES (@GuidID, @ObjectId, @Object, @RepositoryId)";
        public const string UpdateInstance = "UPDATE Instances SET ObjectData = @Object " +
                                           "WHERE GuidID = @GuidID AND RepositoryId = @RepositoryId";
        public const string DeleteInstance = "Delete from Instances WHERE GuidID = @GuidID AND RepositoryId = @RepositoryId";
        public const string ClearInstances = "Delete from Instances WHERE RepositoryId = @RepositoryId";
        public const string ClearAllInstances = "Delete from Instances";
        public const string GetRepositories = "SELECT rps.Name FROM Instances ins inner join Repositories rps on  rps.Id = ins.RepositoryId GROUP BY rps.Name";
        public const string GetObjects = "SELECT Name FROM InstanceTypes WHERE RepositoryId = @RepositoryId Group By Name";
        public const string IsInstanceExists = "Select * from InstanceTypes where Name = @Name AND RepositoryId = @RepositoryId";
        public const string IsRepositoryExists = "Select * from Repositories where Name = @Name";
        public const string InsertNewInstance = "INSERT INTO InstanceTypes (Name, Properties, RepositoryId) VALUES (@Name, @Properties, @RepositoryId)";
        public const string InsertNewRepository = "INSERT INTO Repositories (Name) VALUES (@Name)";
        public const string UpdateInstanceType = "UPDATE InstanceTypes SET Properties = @Properties WHERE Name = @Name AND RepositoryId = @RepositoryId";
    }
}
