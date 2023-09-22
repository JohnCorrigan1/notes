<script setup lang="ts">
import { ref } from 'vue'
import ComponentModal from '@/components/CreatePost/ComponentModal.vue'
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

const modal = ref(false);

const components = ref<Component[]>([]);

const openModal = () => {
    modal.value = true
}

const addComponent = (component: string) => {
    console.log("Adding component: ", component);
    components.value.push({
        component: component,
        props: {}
    })
};

</script>

<template>
    <main class="w-full h-full p-10">
        <form class="flex h-full flex-col w-full gap-10">
            <div class="flex w-full justify-center gap-10">
                <div class="flex flex-col gap-1">
                    <label class="text-white font-semibold text-xl" for="title">Title:</label>
                    <input class="w-80 px-2 py-3 rounded-md" required name="title" placeholder="This is a great title" />
                </div>
                <div class="flex flex-col gap-1">
                    <label class="text-white font-semibold text-xl" for="slug">Slug:</label>
                    <input name="slug" class="w-80 px-2 py-3 rounded-md" placeholder="this-is-a-great-slug" />
                </div>
            </div>

            <div class="w-full h-full flex flex-col justify-center items-center gap-5">
                <label class="text-white font-semibold text-xl" for="">Content</label>
                <div name="content" class="h-full w-2/3 bg-zinc-500 bg-opacity-30 rounded-lg">
                    <component v-for="(component, index) in components" :key="index"
                        :is="componentMapping[component.component]" v-bind="component.props" />
                    <button @click="openModal" type="button"
                        class="w-full h-full bg-zinc-300 bg-opacity-30 hover:bg-opacity-50 active:scale-[0.98] duration-300 rounded-lg justify-center items-center flex flex-col">
                        <div class="flex flex-col justify-center items-center">
                            <img name="addComponent" src="/plus.svg" alt="Add content" class="w-10 text-white h-10" />
                            <!-- <label class="text-lg font-semibold" for="addComponent">New Component</label> -->
                        </div>
                    </button>
                </div>
            </div>
        </form>
        <ComponentModal v-on:choose="addComponent" v-on:close="modal = false" :modal="modal" />
    </main>
</template>