<script setup lang="ts">
import { useUser } from 'vue-clerk'
import { ref, watch } from 'vue'
import type { PostMetaData } from '@/types/types'
import MyPostPreview from '@/components/MyPostPreview.vue'

const posts = ref<PostMetaData[]>();
const livePosts = ref<PostMetaData[]>([]);
const draftPosts = ref<PostMetaData[]>([]);

const isLoading = ref(useUser().isLoaded);
const getPosts = async (clerk_id: string) => {
    const res = await fetch(`${import.meta.env.VITE_BASE_URL}api/post/user/${clerk_id}`);
    const data = await res.json();
    return data as PostMetaData[];
};

watch(isLoading, async () => {
    const user = useUser();
    try {
        posts.value = await getPosts(user.user.value!.id);
    } catch {
        console.log("not ready");
    } finally {
        posts.value?.forEach((post) => {
            if (post.live) {
                livePosts.value.push(post);
            } else {
                draftPosts.value.push(post);
            }
        })
    }
}, { immediate: true }
);
</script>

<template>
    <main>
        <div class="p-10 w-full flex flex-col items-center justify-center gap-10">
            <RouterLink to="/admin/createpost" class="rounded-lg text-zinc-200 font-semibold text-lg px-3 py-2 bg-blue-500 hover:bg-blue-600
                active:scale-[.98] duration-300">
                New Post
            </RouterLink>
            <div class="flex flex-col gap-10">
                <section class="">
                    <h1 class="text-center text-2xl font-semibold text-zinc-200">Live Posts</h1>
                    <div v-if="livePosts.length == 0" class="w-full p-10 flex items-center justify-center">
                        <p class="text-lg font-semibold text-slate-500">No live posts...</p>
                    </div>
                    <div v-else class="w-full grid md:grid-cols-2 lg:grid-cols-3 2xl:grid-cols-4 p-10 gap-10">
                        <MyPostPreview v-for="post in livePosts" :key="post.slug" :slug="post.slug" :title="post.title"
                            :cover="post.cover" :date="post.postedDate" :id="post.slug" />
                    </div>
                </section>
                <section class="">
                    <h1 class="text-center text-2xl font-semibold text-zinc-200">Draft Posts</h1>
                    <div v-if="draftPosts.length == 0" class="w-full p-10 flex items-center justify-center">
                        <p class="text-lg font-semibold text-slate-500">No live posts...</p>
                    </div>
                    <div v-else class="w-full grid md:grid-cols-2 lg:grid-cols-3 2xl:grid-cols-4 p-10 gap-10">
                        <MyPostPreview v-for="post in draftPosts" :key="post.slug" :slug="post.slug" :title="post.title"
                            :cover="post.cover" :date="post.postedDate" :id="post.slug" />
                    </div>
                </section>
            </div>
        </div>
    </main>
</template>
