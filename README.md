# Github Repository Model
(_snappier name needed_)

## Description
Wraps Github Api calls (via [Octokit](https://github.com/octokit/octokit.net)) into a simple to use object model.

Currently only supports reading Repositories and there contents.

Model follows basic pattern

- Setup a up ```Github``` client

- Use the client to get a ```User```
- a ```User``` has one more ```Repositories```
- A ```Repository``` has one or more ```Branches()```
- A ```Branch``` has a root ```Folder``` which contains further ```Folders``` and ```Files```

See the [folder tests](https://github.com/Chrislee187/GithubRepositoryModel/blob/main/src/GithubRepositoryModel.Tests/GhFolderTests.cs) for a simple example.

## Future features

- Commits
- Better handling of date information