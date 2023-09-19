// type User = {
//   id: number
//   username: string
// }

interface User {
  id: number
  username: string
}

interface Post {
  id: number
  title: string
  body: string
  postedDate: string
  authorId: number
  comments: Comment[]
}

// type Post = {
//   id: number
//   title: string
//   body: string
//   postedDate: string
//   authorId: number
//   comments: Comment[]
// }

type PostComment = {
  id: number
  body: string
  postedDate: string
  authorId: number
  postId: number
}

interface Comment {
  id: number
  body: string
  postedDate: string
  authorId: number
  postId: number
}

export type { User, Post, PostComment, Comment }
