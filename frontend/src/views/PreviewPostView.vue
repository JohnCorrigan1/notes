<script setup lang="ts">
import { watch, ref } from 'vue'
import { useRoute } from 'vue-router'
import type { ComponentMapping, Component } from '@/types/types'
import { useUser } from 'vue-clerk'

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
const postFound = ref<boolean>(true);
const slug = route.params.post;

const components = ref<Component[]>([]);
const title = ref<string>("");
const date = ref<string>("");
const author = ref<string>("");

const isLoading = ref(useUser().isLoaded);

const getPost = async (clerkId: string) => {
    await fetch(`${import.meta.env.VITE_BASE_URL}api/post/preview/${clerkId}/${slug}`)
        .then((res) => res.json())
        .then((data) => {
            components.value = JSON.parse(data.components)
            title.value = data.title
            date.value = formatDate(data.postedDate)
            author.value = data.author
        })
        .catch(() => {
            postFound.value = false;
        })
}

watch(isLoading, async () => {
    const user = useUser();
    try {
        await getPost(user.user.value!.id)
    } catch {
        console.log("not found");
    }
}, { immediate: true }
);

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
        <div v-if="postFound" class="w-1/2">
            <PostHeader :title="title" :date="date" :author="author" />
            <component v-for="(component, index) in components" :key="index" :is="componentMapping[component.component]"
                v-bind="component.props" />
        </div>
        <div v-else class="absolute top-1/2 bottom-1/2  p-10 text-zinc-200 text-2xl font-semibold">
            Nothing to see here... yet
        </div>
    </main>
    <footer class="h-20 w-full"></footer>
</template>
