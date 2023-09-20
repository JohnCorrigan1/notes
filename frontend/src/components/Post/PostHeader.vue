<script setup lang="ts">
const { title } = defineProps({
    title: String,
    date: String,
    author: String,
    cover: String
})
</script>

<template>
    <div class="w-full flex items-center justify-center">
        <div class="bg-[url('ve.webp')] bg-cover flex flex-col h-full w-1/2 items-center p-10 gap-10">
            <h1 class="text-3xl font-bold">{{ title }}</h1>
            <div class="flex flex-row gap-10">
                <p class="text-gray-500">{{ date }}</p>
                <p class="text-gray-500">{{ author }}</p>
            </div>
        </div>
    </div>
</template>