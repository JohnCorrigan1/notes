<script setup lang="ts">
import PostHeader from '@/components/Post/PostHeader.vue'
import PostSection from '@/components/Post/PostSection.vue'
import PostImage from '@/components/Post/PostImage.vue'
</script>

<template>
    <main class="text-white w-full h-full flex flex-col items-center pb-10">
        <div class="w-1/2">
            <PostHeader title="Amazing Title" date="September 19, 2023" author="John Corrigan" cover="/vue.webp" />
            <PostSection heading="Epic Post Section" body="lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum 
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum" />
            <PostImage src="/vue.webp" alt="Vue logo" caption="Vue logo made by some cool guy prolly" />
            <PostSection heading="Epic Post Section" body="lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum 
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum" />
        </div>
    </main>
    <footer class="h-20 w-full">

    </footer>
</template>
