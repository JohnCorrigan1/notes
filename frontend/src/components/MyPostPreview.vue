<script setup lang="ts">
import { defineProps, ref } from 'vue';
import { RouterLink } from 'vue-router';
import { useUser } from 'vue-clerk';

const { title, cover, date, slug } = defineProps({
    title: String,
    cover: String,
    date: String,
    slug: String,
    postId: Number,
    live: Boolean,
})

const user = useUser();
const modal = ref(false);

const formattedDate = new Date(date!).toLocaleDateString("en-US", {
    year: "numeric",
    month: "long",
    day: "numeric"
})

const publish = async () => {
    const clerkId = user.user.value!.id;
    await fetch(`${import.meta.env.VITE_BASE_URL}api/post/publish/${clerkId}/${slug}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            live: true
        })
    })
}

const unpublish = async () => {
    const clerkId = user.user.value!.id;
    const res = await fetch(`${import.meta.env.VITE_BASE_URL}api/post/publish/${clerkId}/${slug}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            live: false
        })
    })

    console.log(res);
}

const deletePost = async () => {
    const clerkId = user.user.value!.id;
    const res = await fetch(`${import.meta.env.VITE_BASE_URL}api/post/delete/${clerkId}/${slug}`, {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json"
        },
    })
    modal.value = false;
    console.log(res);
}

const confirmDelete = () => {
    modal.value = true;
}

const closeModal = () => {
    modal.value = false;
}

const titleLink = `/admin/${slug}/preview`
</script>

<template>
    <div class="flex flex-col rounded-lg bg-zinc-400 bg-opacity-20 cursor-pointer">
        <img :src="cover" :alt="title" class="w-full object-cover rounded-t-lg" />
        <div class="flex flex-col items-center p-5">
            <h3 class="text-xl font-semibold">{{ title }}</h3>
            <p class="text-gray-500">{{ formattedDate }}</p>
            <div class="flex gap-5 pt-5">
                <RouterLink :to="titleLink" class="rounded-lg text-zinc-200 font-semibold  w-20 text-center py-2 bg-blue-500 hover:bg-blue-600
                    active:scale-[.98] duration-300">
                    Preview
                </RouterLink>
                <RouterLink :to="`/admin/${slug}/edit`" class="rounded-lg text-zinc-200 font-semibold w-20 text-center py-2 bg-blue-500 hover:bg-blue-600
                    active:scale-[.98] duration-300">
                    Edit
                </RouterLink>

            </div>
            <div class="flex gap-5 pt-5">
                <button @click="publish" v-if="live == false" class=" rounded-lg text-zinc-200 font-semibold w-20 text-center py-2 bg-emerald-500
                hover:bg-emerald-600 active:scale-[.98] duration-300">Publish</button>
                <button @click="unpublish" v-else class=" rounded-lg text-zinc-200 font-semibold w-20 text-center py-2 bg-rose-500
                hover:bg-rose-600 active:scale-[.98] duration-300">Hide</button>
                <button @click="confirmDelete" class=" rounded-lg text-zinc-200 font-semibold w-20 text-center py-2 bg-rose-500
                hover:bg-rose-600 active:scale-[.98] duration-300">Delete</button>
            </div>
        </div>
    </div>
    <div v-if="modal" @click="closeModal" class="bg-zinc-900 bg-opacity-60 z-0 fixed top-0 right-0 w-screen h-screen">
    </div>
    <div v-if="modal"
        class="overflow-y-scroll z-[50] rounded-lg w-1/2 h-1/2 max-w-1/2 max-h-1/2 fixed top-[25%] right-[25%] bg-zinc-600 p-5">
        <div class="flex flex-col gap-5 w-full h-full justify-center items-center">
            <h2 class="font-semibold text-zinc-200 text-lg">Are you sure you?</h2>
            <div class="flex gap-5">
                <button @click="deletePost" class="rounded-lg text-zinc-200 font-semibold w-20 text-center py-2 bg-rose-500
                hover:bg-rose-600 active:scale-[.98] duration-300">Yes</button>
                <button @click="closeModal" class=" rounded-lg text-zinc-200 font-semibold w-20 text-center py-2 bg-blue-500
                hover:bg-blue-600 active:scale-[.98] duration-300">No</button>
            </div>
        </div>
    </div>
</template>
