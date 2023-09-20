<script setup lang="ts">
const { toShow, url } = defineProps({
    toShow: String,
    url: String
})
</script>

<template>
    <a :href="url" target="_blank" class="text-blue-400 hover:underline">{{ toShow }}</a>
</template>