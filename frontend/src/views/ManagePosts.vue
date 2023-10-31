<script setup lang="ts">
import { useUser } from 'vue-clerk'
import { onMounted, ref } from 'vue'
import type { PostMetadata } from '@/types/types'

const posts = ref<PostMetaData[]>();

const getPosts = async () => {
    const res = await fetch(`${import.meta.env.VITE_BASE_URL}/api/posts`);
    const data = await res.json();
    return data as PostMetaData[];
};

onMounted(async () => {
    posts.value = await getPosts();
});

</script>

<template>
    <main>
        <div class="p-10 w-full flex items-center justify-center">
            <RouterLink to="/admin/howdidufinddis/createpost">
                <button
                    class="rounded-lg text-zinc-200 font-semibold text-lg px-3 py-2 bg-blue-500 hover:bg-blue-600 active:scale-[.98] duration-300">
                    New Post
                </button>
            </RouterLink>
        </div>
    </main>
</template>

