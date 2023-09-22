<script setup lang="ts">
import { ref } from 'vue'

const modal = ref(false)

const closeModal = () => {
    modal.value = false
}

const openModal = () => {
    modal.value = true
}


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
        <div v-if="modal" @click="closeModal"
            class="bg-zinc-900 bg-opacity-60 z-0 absolute top-0 right-0 w-screen h-screen"></div>
        <div v-if="modal"
            class="z-[50] rounded-lg w-2/3 h-2/3 max-w-2/3 max-h-2/3 absolute top-[16.67%] right-[16.67%] bg-white">

        </div>
    </main>
</template>