<script setup lang="ts">
const { title, date, author } = defineProps({
    title: String,
    date: String,
    author: String,
})
</script>

<template>
    <div class="w-full flex items-center justify-center">
        <div class="flex flex-col h-full w-full items-center p-10 gap-10">
            <h1 class="text-3xl font-bold">{{ title }}</h1>
            <div class="flex flex-row gap-12">
                <p class="text-gray-500">{{ date }}</p>
                <p class="text-gray-500">{{ author }}</p>
            </div>
        </div>
    </div>
</template>
