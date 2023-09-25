import type { ComponentPreview } from '@/types/types'

const getMap = () => {
  const componentProps = new Map<string, any>()

  componentProps.set('PostSection', {
    heading: '',
    body: ''
  })

  componentProps.set('PostImage', {
    src: '',
    caption: ''
  })

  componentProps.set('PostCodeBlock', {
    language: '',
    code: ''
  })

  componentProps.set('PostTextAndImage', {
    body: '',
    alt: '',
    src: '',
    caption: ''
  })

  componentProps.set('PostSectionUl', {
    heading: '',
    subheading: '',
    items: []
  })

  componentProps.set('PostSectionOl', {
    heading: '',
    subheading: '',
    items: []
  })

  componentProps.set('PostListMiddleUl', {
    items: []
  })

  componentProps.set('PostListMiddleOl', {
    items: []
  })

  componentProps.set('PostParagraph', {
    body: ''
  })
  return componentProps
}

const components: ComponentPreview[] = [
  {
    component: 'PostHeader',
    name: 'Header',
    src: '/vue.webp'
  },
  {
    component: 'PostSection',
    name: 'Section',
    src: '/vue.webp'
  },
  {
    component: 'PostImage',
    name: 'Image',
    src: '/vue.webp'
  },
  {
    component: 'PostCodeBlock',
    name: 'Code Block',
    src: '/vue.webp'
  },
  {
    component: 'PostTextAndImage',
    name: 'Text and Image',
    src: '/vue.webp'
  },
  {
    component: 'PostSectionUl',
    name: 'Section Unordered List',
    src: '/vue.webp'
  },
  {
    component: 'PostSectionOl',
    name: 'Section Ordered List',
    src: '/vue.webp'
  },
  {
    component: 'PostListMiddleUl',
    name: 'List Middle Unordered List',
    src: '/vue.webp'
  },
  {
    component: 'PostListMiddleOl',
    name: 'List Middle Ordered List',
    src: '/vue.webp'
  },
  {
    component: 'PostParagraph',
    name: 'Paragraph',
    src: '/vue.webp'
  }
]

export { getMap, components }
