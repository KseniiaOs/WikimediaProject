# How to run WikimediaProject
1. Install .NET SDK 7: You can download it from the official .NET website: https://dotnet.microsoft.com/download.
2. Clone the  repository https://github.com/KseniiaOs/WikimediaProject.git
3. Build the Project being located in dir containing WikiApi.csproj.
    use dotnet build command
4. Run the test
    use dotnet test command


# Part 2
# Checklists
# Will cover two resources /core/v1/{project}/{language}/search/page?q=search terms

1. Checking possible pairs {projects} and {lanquage} for search page resource
2. Checking possible pairs {q} and {lanquage} for search page resource
3. Checking query parameter q by searching different propertyes such as (duration, height, id) for search page resource
4. Checking without using one or more required query parameters - project/ language / q
5. Checking use of the optional query parameter limit - {0, 1, 99, 100, 101, -1}
6. During tests check for expected  responses (400 if any of required params wasn't provided or limit not between 1 and 100 )
etc

# and
# /core/v1/{project}/{language}/page/{title}/bare
1. Checking possible pairs {projects} and {lanquage} for page details resource
2. Checking possible pairs {language} and {title} for page details resource
3. Checking for correct responses (Not Found and The specified title does not exist)
4. Checking for correct information in Successful responses.
etc


