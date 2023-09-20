<script setup lang="ts">
const { body } = defineProps({
    body: String
})
</script>

<template>
    <p class="pt-10">{{ body }}</p>
</template>