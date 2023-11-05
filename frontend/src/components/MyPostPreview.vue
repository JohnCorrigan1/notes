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

const titleLink = `/admin/${slug}/preview`
</script>

<template>
    <div class="flex flex-col rounded-lg bg-zinc-400 bg-opacity-20 cursor-pointer">
        <img :src="cover" :alt="title" class="w-full object-cover rounded-t-lg" />
        <div class="flex flex-col items-center p-5">
            <h3 class="text-xl font-semibold">{{ title }}</h3>
            <p class="text-gray-500">{{ formattedDate }}</p>
            <div class="flex gap-5 pt-5">
                <RouterLink :to="titleLink" class="rounded-lg text-zinc-200 font-semibold  w-20 text-center py-2 bg-blue-500 hover:bg-blue-600
                    active:scale-[.98] duration-300">
                    Preview
                </RouterLink>
                <RouterLink :to="`/admin/${slug}/edit`" class="rounded-lg text-zinc-200 font-semibold w-20 text-center py-2 bg-blue-500 hover:bg-blue-600
                    active:scale-[.98] duration-300">
                    Edit
                </RouterLink>
            </div>
        </div>
    </div>
</template>
