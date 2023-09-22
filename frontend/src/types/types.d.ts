import type { type } from 'os'

type User = {
  id: number
  username: string
}

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
  editComponent: string
  props: any
}

type EditComponent = {
  editComponent: string
  component: string
  props: any
  index: number
}

type PostSection = {
  component: 'PostSection'
  editComponent: 'EditPostSection'
  props: {
    heading: string
    body: string
  }
}

type EditPostSection = {
  editComponent: 'EditPostSection'
  component: 'PostSection'
  props: {
    heading: string
    body: string
  }
}

type PostImage = {
  component: 'PostImage'
  editComponent: 'EditPostImage'
  props: {
    src: string
    caption: string
  }
}

type EditPostImage = {
  editComponent: 'EditPostImage'
  component: 'PostImage'
  props: {
    src: string
    caption: string
  }
}

type PostCodeBlock = {
  component: 'PostCodeBlock'
  editComponent: 'EditPostCodeBlock'
  props: {
    code: string
    language: string
  }
}

type EditPostCodeBlock = {
  editComponent: 'EditPostCodeBlock'
  component: 'PostCodeBlock'
  props: {
    code: string
    language: string
  }
}

type PostTextAndImage = {
  component: 'PostTextAndImage'
  editComponnt: 'EditPostTextAndImage'
  props: {
    body: string
    src: string
    alt: string
    caption: string
  }
}

type EditPostTextAndImage = {
  editComponent: 'EditPostTextAndImage'
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
  editComponent: 'EditPostSectionUl'
  props: {
    heading: string
    subheading: string
    items: string[]
  }
}

type EditPostSectionUl = {
  editComponent: 'EditPostSectionUl'
  component: 'PostSectionUl'
  props: {
    heading: string
    subheading: string
    items: string[]
  }
}

type PostSectionOl = {
  component: 'PostSectionOl'
  editComponent: 'EditPostSectionOl'
  props: {
    heading: string
    subheading: string
    items: string[]
  }
}

type EditPostSectionOl = {
  editComponent: 'EditPostSectionOl'
  component: 'PostSectionOl'
  props: {
    heading: string
    subheading: string
    items: string[]
  }
}

type PostListMiddleUl = {
  component: 'PostListMiddleUl'
  editComponent: 'EditPostListMiddleUl'
  props: {
    items: string[]
  }
}

type EditPostListMiddleUl = {
  editComponent: 'EditPostListMiddleUl'
  props: {
    items: string[]
  }
}

type PostListMiddleOl = {
  component: 'PostListMiddleOl'
  editComponent: 'EditPostListMiddleOl'
  props: {
    items: string[]
  }
}

type EditPostListMiddleOl = {
  editComponent: 'EditPostListMiddleOl'
  component: 'PostListMiddleOl'
  props: {
    items: string[]
  }
}

type PostParagraph = {
  component: 'PostParagraph'
  editComponent: 'EditPostParagraph'
  props: {
    body: string
  }
}

type EditPostParagraph = {
  editComponent: 'EditPostParagraph'
  component: 'PostParagraph'
  props: {
    body: string
  }
}

type ComponentPreview = {
  component: string
  name: string
  src: string
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
  PostParagraph,
  EditComponent,
  EditPostSection,
  EditPostImage,
  EditPostCodeBlock,
  EditPostTextAndImage,
  EditPostSectionUl,
  EditPostSectionOl,
  EditPostListMiddleUl,
  EditPostListMiddleOl,
  EditPostParagraph,
  PostMetaData,
  ComponentPreview
}
