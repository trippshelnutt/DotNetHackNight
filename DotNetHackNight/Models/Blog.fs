namespace DotNetHackNight

open System

type TagType = string

type UserIdType = Guid
type CommentIdType = Guid
type BlogPostIdType = Guid

type UserType = { Id : UserIdType; UserName : string; DisplayName : string; FirstName : string; LastName : string }
type CommentType = { Id : CommentIdType; BlogPostId : BlogPostIdType; UserId : UserIdType; Content : string }
type BlogPostType = { Id : BlogPostIdType; AuthorId : UserIdType; Title : string; Content : string; Comments : CommentType list; Tags : TagType list }

module Blog =
    let createUser (userName) (displayName) (firstName) (lastName) =
        { Id = Guid.NewGuid(); UserName = userName; DisplayName = displayName; FirstName = firstName; LastName = lastName }

    let createBlogPost (authorId) (title) (content) =
        { Id = Guid.NewGuid(); AuthorId = authorId; Title = title; Content = content; Tags = []; Comments = [] }

    let addTags (blogPost) (tags) =
        { blogPost with Tags = blogPost.Tags |> List.append tags }

    let createBlogPostWithTags (authorId) (title) (content) (tags) =
        addTags (createBlogPost authorId title content) tags

    let createComment (blogPostId) (userId) (content) =
        { Id = Guid.NewGuid(); BlogPostId = blogPostId; UserId = userId; Content = content }

    let addComment (blogPost) (comment) =
        { blogPost with Comments = blogPost.Comments |> List.append [comment] }
