import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import { useAuth, useClerk } from 'vue-clerk'
import { onMounted } from 'vue'
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
      props: true
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
      path: '/admin/howdidufinddis/createpost',
      name: 'CreatePost',
      component: () => import('../views/CreatePostView.vue'),
      meta: {
        requiresAuth: true
      }
    }
  ]
})

router.beforeEach((to, from, next) => {
  const { isSignedIn } = useAuth()
  if (to.matched.some((record) => record.meta.requiresAuth)) {
    if (isSignedIn.value) {
      next() 
    } else {
      const clerk = useClerk()
      clerk.openSignIn({appearance: dark})
    }
  } else {
    next() 
    }
})

export default router
