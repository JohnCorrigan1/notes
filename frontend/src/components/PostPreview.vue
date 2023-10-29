<script setup lang="ts">
import { RouterLink } from 'vue-router';

const { title, cover, date, slug } = defineProps({
    title: String,
    cover: String,
    date: String,
    slug: String,
    postId: Number,
})

const formattedDate = new Date(date!).toLocaleDateString("en-US", {
    year: "numeric",
    month: "long",
    day: "numeric"
})

const titleLink = `/${slug}`
</script>

<template>
    <RouterLink :to="titleLink">
        <div class="flex flex-col rounded-lg bg-zinc-400 hover:bg-opacity-40 bg-opacity-20 duration-300 cursor-pointer">
            <img :src="cover" :alt="title" class="w-full object-cover rounded-t-lg" />
            <div class="flex flex-col items-center p-5">
                <h3 class="text-xl font-semibold">{{ title }}</h3>
                <p class="text-gray-500">{{ formattedDate }}</p>
            </div>
        </div>
    </RouterLink>
</template>
