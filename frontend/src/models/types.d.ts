type User = {
  id: number
  username: string
}

type Post = {
  id: number
  title: string
  body: string
  postedDate: string
  likes: number
  authorId: number
}

type PostComment = {
  id: number
  body: string
  postedDate: string
  authorId: number
  postId: number
}

export type { User, Post, PostComment }
