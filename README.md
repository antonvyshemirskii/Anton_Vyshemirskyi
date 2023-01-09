1.Clone my repository
2.my token should work but if not follow next:
 2.1 create Dropbox app
 2.2 Give Permission for files.metadata.write, files.content.write, files.content.read(click submit)
 2.3 Generate token
 2.4 open WebAPI.sln
 2.5 open Client.cs and change GenToken to received token
 2.6 Run Tests in UnitTest1.cs
 
3.To run from terminal you need to do previous steps if token doesn't work
4.open terminal and write:
dotnet test [folder where repositiry is]/WebAPI/bin/Debug/net7.0/WebAPI.dll
