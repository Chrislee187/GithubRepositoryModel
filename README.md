# Github Repository Model
(_snappier name needed_)

## Description
Wraps Github Api calls (via [Octokit](https://github.com/octokit/octokit.net)) into a simple to use object model.

Currently only supports reading Repositories and there contents.

The follows has the following basic structure;

- Given a `Github` client.
- Use the client to get a `GhUser`.
- a `GhUser` has one more `GhRepository`'s.
- A `GhRepository` has one or more `GhBranch`'s.
- A `GhBranch` has a root `GhFolder` which contains further `GhFolder`'s and `GhFile`'s.

See the [folder tests](https://github.com/Chrislee187/GithubRepositoryModel/blob/main/src/GithubRepositoryModel.Tests/GhFolderTests.cs) for a simple example.

## Possible future features

- Commits
- Better handling of date information