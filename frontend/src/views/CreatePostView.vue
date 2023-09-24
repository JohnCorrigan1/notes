<script setup lang="ts">
import { ref } from 'vue'
import ComponentModal from '@/components/CreatePost/ComponentModal.vue'
import type { ComponentMapping, Component, PostData, PostMetaData } from '@/types/types'
//edit import components
import EditPostSection from '@/components/CreatePost/EditComponents/EditPostSection.vue'
import EditPostImage from '@/components/CreatePost/EditComponents/EditPostImage.vue'
import EditPostCodeBlock from '@/components/CreatePost/EditComponents/EditPostCodeBlock.vue'
import EditPostTextAndImage from '@/components/CreatePost/EditComponents/EditPostTextAndImage.vue';
import EditPostSectionUl from '@/components/CreatePost/EditComponents/EditPostSectionUl.vue';
import EditPostSectionOl from '@/components/CreatePost/EditComponents/EditPostSectionOl.vue';
import EditPostListMiddleUl from '@/components/CreatePost/EditComponents/EditPostListMiddleUl.vue';
import EditPostListMiddleOl from '@/components/CreatePost/EditComponents/EditPostListMiddleOl.vue';
import EditPostParagraph from '@/components/CreatePost/EditComponents/EditPostParagraph.vue';

const editComponentMapping: ComponentMapping = {
    "EditPostSection": EditPostSection,
    "EditPostImage": EditPostImage,
    "EditPostCodeBlock": EditPostCodeBlock,
    "EditPostTextAndImage": EditPostTextAndImage,
    "EditPostSectionUl": EditPostSectionUl,
    "EditPostSectionOl": EditPostSectionOl,
    "EditPostListMiddleUl": EditPostListMiddleUl,
    "EditPostListMiddleOl": EditPostListMiddleOl,
    "EditPostParagraph": EditPostParagraph
};

const modal = ref(false);
const title = ref("");
const slug = ref("");

const editComponents = ref<Component[]>([]);

const postMetaData = ref<PostMetaData>({
    slug: slug.value,
    title: title.value,
    postedDate: "September 23, 2023",
    cover: "/vue.webp",
    likes: 0,
    author: "John Corrigan",
    tags: []
});

const postData = ref<PostData>(
    {
        title: title.value,
        date: "September 23, 2023",
        author: "John Corrigan",
        cover: "/vue.webp",
        components: []
    }
);
// { component: "PostSection", editComponent: "EditPostSection", props: { title: title.value, date: Date.now(), author: "John Corrigan", cover: "/vue.webp" } }
const openModal = () => {
    modal.value = true
}

const addComponent = (component: string) => {
    console.log("Adding component: ", component);
    editComponents.value.push({
        component: component,
        editComponent: "Edit" + component,
        props: {}
    })
};

const addPost = () => {
    console.log(editComponents)
    // console.log("Adding post");
    // const componentsArray: Component[] = [];
    // components.forEach((component, index) => {
    //     componentsArray.push({
    //         component: component.getAttribute("data-component") as string,
    //         props: JSON.parse(props[index].innerHTML)
    //     })
    // })
    // const data = {
    //     title: title.value,
    //     slug: slug.value,
    //     components: JSON.stringify(componentsArray)
    // }
    // fetch("https://localhost:7010/api/post", {
    //     method: "POST",
    //     headers: {
    //         "Content-Type": "application/json"
    //     },
    //     body: JSON.stringify(data)
    // })
    //     .then((res) => res.json())
    //     .then((data) => {
    //         console.log(data);
    //     })
    //     .catch((err) => {
    //         console.log(err);
    //     })
}

</script>

<template>
    <main class="w-full h-full p-10">
        <form class="flex h-full flex-col w-full gap-10">
            <div class="flex w-full justify-center gap-10">
                <div class="flex flex-col gap-1">
                    <label class="text-white font-semibold text-xl" for="title">Title:</label>
                    <input v-model="title" class="w-80 px-2 py-3 rounded-md" required name="title"
                        placeholder="This is a great title" />
                </div>
                <div class="flex flex-col gap-1">
                    <label class="text-white font-semibold text-xl" for="slug">Slug:</label>
                    <input v-model="slug" name="slug" class="w-80 px-2 py-3 rounded-md"
                        placeholder="this-is-a-great-slug" />
                </div>
            </div>

            <div class="w-full h-full flex flex-col justify-center items-center gap-5">
                <label class="text-white font-semibold text-xl" for="">Content</label>
                <div id="content" name="content" class="h-full w-2/3 bg-zinc-500 bg-opacity-30 rounded-lg">
                    <!-- <EditPostSection /> -->
                    <component v-for="(component, index) in editComponents" :key="index"
                        :is="editComponentMapping[component.editComponent]" v-bind="component.props" />
                    <button @click="openModal" type="button"
                        class="w-full h-full min-h-[300px] bg-zinc-300 bg-opacity-30 hover:bg-opacity-50 active:scale-[0.98] duration-300 rounded-lg justify-center items-center flex flex-col">
                        <div class="flex flex-col justify-center items-center">
                            <img name="addComponent" src="/plus.svg" alt="Add content" class="w-10 text-white h-10" />
                            <!-- <label class="text-lg font-semibold" for="addComponent">New Component</label> -->
                        </div>
                    </button>
                </div>
                <div class="w-full flex justify-center items-center">
                    <button @click="addPost" type="button"
                        class=" min-w-[150px] text-white rounded-lg font-semibold py-2 px-3 bg-blue-500 hover:bg-blue-600 active:scale-[0.97] duration-300">Save</button>
                </div>
            </div>
        </form>
        <ComponentModal v-on:choose="addComponent" v-on:close="modal = false" :modal="modal" />
    </main>
</template>