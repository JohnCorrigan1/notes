<script setup lang="ts">
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

const componentMapping: any = {
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

const postData: any = {
    "title": "Amazing Title",
    "date": "September 19, 2023",
    "author": "John Corrigan",
    "cover": "/vue.webp",
    "components": [
        {
            "component": "PostSection",
            "props": {
                "heading": "Epic Post Section",
                "body": "lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lo"
            }
        },
        {
            "component": "PostImage",
            "props": {
                "src": "/vue.webp",
                "caption": "Vue logo made by some cool guy prolly"
            }
        }
    ]
}

</script>

<template>
    <main class="text-white w-full h-full flex flex-col items-center pb-10">
        <div class="w-1/2">
            <PostHeader :title="postData.title" :date="postData.date" :author="postData.author" :cover="postData.cover" />

            <component v-for="(component, index) in postData.components" :key="index"
                :is="componentMapping[component.component]" v-bind="component.props" />

            <!-- <PostSection heading="Epic Post Section" body="lorem ipsum lorem ipsum lorem ipsum lorem ipsum
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

            <PostCodeBlock code="const helloWorld = &quot;Hello World!&quot;" language="javascript" />
            <PostCodeBlock code="const helloWorld = Hello World!" language="javascript" />
            <PostTextAndImage caption="Vue logo made by some cool guy prolly" src="/vue.webp" body="lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum 
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum" />

            <PostSectionUl heading="Epic Post Section"
                :items="['lorem ipsum lorem ipsum lorem ipsum lorem ipsum', 'lorem ipsum lorem ipsum lorem ipsum lorem ipsum', 'lorem ipsum lorem ipsum lorem ipsum lorem ipsum', 'lorem ipsum lorem ipsum lorem ipsum lorem ipsum', 'lorem ipsum lorem ipsum lorem ipsum lorem ipsum']" />

            <PostParagraph body="lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum 
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum" />

            <PostSectionOl heading="" subheading="Epic Post subsection"
                :items="['lorem ipsum lorem ipsum lorem ipsum lorem ipsum', 'lorem ipsum lorem ipsum lorem ipsum lorem ipsum', 'lorem ipsum lorem ipsum lorem ipsum lorem ipsum', 'lorem ipsum lorem ipsum lorem ipsum lorem ipsum', 'lorem ipsum lorem ipsum lorem ipsum lorem ipsum']" />

            <PostParagraph body="lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum 
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum" />

            <PostListMiddleUl
                :items="['lorem ipsum lorem ipsum lorem ipsum lorem ipsum', 'lorem ipsum lorem ipsum lorem ipsum lorem ipsum', 'lorem ipsum lorem ipsum lorem ipsum lorem ipsum', 'lorem ipsum lorem ipsum lorem ipsum lorem ipsum', 'lorem ipsum lorem ipsum lorem ipsum lorem ipsum']" />

            <PostParagraph body="lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum 
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum" />

            <PostListMiddleOl
                :items="['lorem ipsum lorem ipsum lorem ipsum lorem ipsum', 'lorem ipsum lorem ipsum lorem ipsum lorem ipsum', 'lorem ipsum lorem ipsum lorem ipsum lorem ipsum', 'lorem ipsum lorem ipsum lorem ipsum lorem ipsum', 'lorem ipsum lorem ipsum lorem ipsum lorem ipsum']" />

            <PostParagraph body="lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum 
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum
            lorem ipsum lorem ipsum lorem ipsum lorem ipsum" /> -->

        </div>
    </main>
    <footer class="h-20 w-full">

    </footer>
</template>
