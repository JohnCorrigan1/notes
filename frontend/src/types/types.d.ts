import type { type } from 'os'

type User = {
  id: number
  username: string
}
/*
This sentence is 50 characters long starting now.
This sentence is a bit longer than the first one its 60 cha 
This sentence is even longer than the second one it is 70 characters.
This sentence will be 10 longer than the third one it is 80 characters long now.
This sentence will be 10 characters longer than the fourth one it is 90 characters long...
This sentence will be 10 characters longer than the fifth one it is 100 characters long... sldkfsal
*/
type PostMetaData = {
  slug: string
  title: string
  postedDate: string
  cover: string
  likes: number
  author: string
  tags: string[]
}

type Post = {
  id: number
  slug: string
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

type PostData = {
  title: string
  date: string
  author: string
  cover: string
  components: Component[]
}

type ComponentMapping = {
  [key: string]: any
}

type Component = {
  component: string
  props: any
}

type PostSection = {
  component: 'PostSection'
  props: {
    heading: string
    body: string
  }
}

type PostImage = {
  component: 'PostImage'
  props: {
    src: string
    caption: string
  }
}

type PostCodeBlock = {
  component: 'PostCodeBlock'
  props: {
    code: string
    language: string
  }
}

type PostTextAndImage = {
  component: 'PostTextAndImage'
  props: {
    body: string
    src: string
    alt: string
    caption: string
  }
}

type PostSectionUl = {
  component: 'PostSectionUl'
  props: {
    heading: string
    subheading: string
    items: string[]
  }
}

type PostSectionOl = {
  component: 'PostSectionOl'
  props: {
    heading: string
    subheading: string
    items: string[]
  }
}

type PostListMiddleUl = {
  component: 'PostListMiddleUl'
  props: {
    items: string[]
  }
}

type PostListMiddleOl = {
  component: 'PostListMiddleOl'
  props: {
    items: string[]
  }
}

type PostParagraph = {
  component: 'PostParagraph'
  props: {
    body: string
  }
}

export type {
  User,
  Post,
  PostComment,
  PostData,
  ComponentMapping,
  Component,
  PostSection,
  PostImage,
  PostCodeBlock,
  PostTextAndImage,
  PostSectionUl,
  PostSectionOl,
  PostListMiddleUl,
  PostListMiddleOl,
  PostParagraph
}
