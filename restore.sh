#!/bin/bash
projects=(Testarossa.Tests Testarossa.IntegrationTests Testarossa.Core Testarossa.Api Testarossa.Infrastructure)
for project in ${projects[*]}
do
	echo restoring project: $project
	dotnet restore
done