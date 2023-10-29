<script setup lang="ts">
import PostPreview from './PostPreview.vue'
import { onMounted, ref } from 'vue'
import type { PostMetaData } from '@/types/types'

const posts = ref<PostMetaData[]>();

const getPosts = async () => {
    const res = await fetch(`${import.meta.env.VITE_BASE_URL}api/post`)
    const postsResponse = await res.json()
    return postsResponse as PostMetaData[]
}

onMounted(() => {
    getPosts()
        .then((postList) => {
            console.log(postList)
            posts.value = postList as PostMetaData[]
            console.log(posts.value)
        })
        .catch((err) => {
            console.log(err)
        })
});
</script>

<template>
    <div class="w-full grid md:grid-cols-2 lg:grid-cols-3 2xl:grid-cols-4 p-10 gap-10">
        <PostPreview v-for="post in posts" :key="post.slug" :slug="post.slug" :title="post.title" :cover="post.cover"
            :date="post.postedDate" :id="post.slug" />
    </div>
</template>
