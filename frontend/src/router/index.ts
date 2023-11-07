import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import { useAuth, useClerk, useUser } from 'vue-clerk'
import { watch, ref } from 'vue'
import { dark } from '@clerk/themes'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/:post',
      name: 'post',
      component: () => import('../views/PostView.vue'),
//      props: true
    },
    {
        path: '/admin/:post/preview',
            name: 'PreviewPost',
        component: () => import('../views/PreviewPostView.vue'),
        meta: {
            requiresAuth: true
            }
    },
    {
        path: '/admin/:post/edit',
            name: 'EditPost',
        component: () => import('../views/EditPostView.vue'),
        meta: {
            requiresAuth: true
            }
    },
    {
      path: '/admin',
      name: 'Admin',
      component: () => import('../views/ManagePosts.vue'),
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/admin/createpost',
      name: 'CreatePost',
      component: () => import('../views/CreatePostView.vue'),
      meta: {
        requiresAuth: true
      }
    }
  ]
})

router.beforeResolve(async (to, from, next) => {
  const { isSignedIn } = useAuth()
  const isLoading = ref(useUser().isLoaded)
  if (!isLoading.value) {
    await new Promise<void>((resolve) => {
      const unsubscribe = watch(isLoading, (value) => {
        if (value) {
          unsubscribe()
          resolve()
        }
      })
    })
  }

  if (to.matched.some((record) => record.meta.requiresAuth)) {
    if (isSignedIn.value) {
      next()
    } else {
      const clerk = useClerk()
      clerk.openSignIn({ appearance: dark, afterSignInUrl: '/admin' })
      next({ name: 'Home' })
    }
  } else {
    next()
  }
})

export default router
