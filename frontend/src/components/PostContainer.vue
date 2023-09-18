<script setup lang="ts">
import PostPreview from './PostPreview.vue'
</script>

<template>
    <div class="w-full grid grid-cols-3 p-10 gap-10">
        <PostPreview title="This is a title" cover="/vue.webp" date="Septemer 17, 2023" />
        <PostPreview title="This is a title" cover="/vue.webp" date="Septemer 17, 2023" />
        <PostPreview title="This is a title" cover="/vue.webp" date="Septemer 17, 2023" />
    </div>
</template>
