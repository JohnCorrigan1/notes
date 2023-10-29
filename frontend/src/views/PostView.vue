<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { useRoute } from 'vue-router'
import type { ComponentMapping, Component } from '@/types/types'
//component imports
import PostHeader from '@/components/Post/PostHeader.vue'
import PostSection from '@/components/Post/PostSection.vue'
import PostImage from '@/components/Post/PostImage.vue'
import PostCodeBlock from '@/components/Post/PostCodeBlock.vue'
import PostTextAndImage from '@/components/Post/PostTextAndImage.vue';
import PostSectionUl from '@/components/Post/PostSectionUl.vue';
import PostSectionOl from '@/components/Post/PostSectionOl.vue';
import PostListMiddleUl from '@/components/Post/PostListMiddleUl.vue';
import PostListMiddleOl from '@/components/Post/PostListMiddleOl.vue';
import PostParagraph from '@/components/Post/PostParagraph.vue';

const componentMapping: ComponentMapping = {
    "PostSection": PostSection,
    "PostImage": PostImage,
    "PostCodeBlock": PostCodeBlock,
    "PostTextAndImage": PostTextAndImage,
    "PostSectionUl": PostSectionUl,
    "PostSectionOl": PostSectionOl,
    "PostListMiddleUl": PostListMiddleUl,
    "PostListMiddleOl": PostListMiddleOl,
    "PostParagraph": PostParagraph
};

const route = useRoute();

const slug = route.params.post;

const components = ref<Component[]>([]);
const title = ref<string>("");
const date = ref<string>("");
const author = ref<string>("");

onMounted(() => {
    fetch(`https://localhost:7010/api/post/${slug}`)
        //fetch(`https://johnnotesapi.azurewebsites.net/api/post/${slug}`)
        .then((res) => res.json())
        .then((data) => {
            components.value = JSON.parse(data.components)
            title.value = data.title
            date.value = formatDate(data.postedDate)
            author.value = data.author
        })
        .catch((err) => {
            console.log(err);
        })
});

const formatDate = (date: string) => {
    const dateReal = date?.replace('T', ' ').replace('-', '/');
    return new Date(dateReal!).toLocaleDateString('en-US', {
        year: 'numeric',
        month: 'long',
        day: 'numeric'
    }).toString();
}





</script>

<template>
    <main class="text-white w-full h-full flex flex-col items-center pb-10">
        <div class="w-1/2">
            <PostHeader :title="title" :date="date" :author="author" />
            <component v-for="(component, index) in components" :key="index" :is="componentMapping[component.component]"
                v-bind="component.props" />
        </div>
    </main>
    <footer class="h-20 w-full"></footer>
</template>
