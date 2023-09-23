<script setup lang="ts">
import { ref } from 'vue'

const { type, label } = defineProps({
    type: String,
    label: String
});

const open = ref<HTMLElement>();
const closed = ref<HTMLElement>();

const collapseExpand = () => {
    if (!open.value || !closed.value) return console.error("open or closed ref is null");
    if (open?.value.classList.contains("hidden")) {
        open?.value.classList.remove("hidden");
        closed?.value.classList.add("hidden");
    } else {
        open?.value.classList.add("hidden");
        closed?.value.classList.remove("hidden");
        closed?.value.classList.add("flex");
    }
}
</script>

<template>
    <div ref="open" class="w-full border-2 relative flex flex-col">
        <div class="flex p-5 justify-center items-center w-full">
            <h1 class="text-2xl text-white font-bold">{{ type }}</h1>
        </div>
        <form class="flex flex-col w-full gap-5 p-5">
            <slot></slot>
        </form>
        <button @click="collapseExpand" type="button"
            class="absolute top-3 left-3 opacity-60 hover:opacity-100 hover:scale-[1.02] active:scale-[0.98] duration-300">
            <img class="h-10 w-10" src="/collapse.svg" alt="collapse/expand" />
        </button>
    </div>
    <div ref="closed" class="w-full border-2 relative hidden justify-center items-center p-5 ">
        <p class="text-xl font-semibold text-white">{{ type }}: {{ label }}</p>
        <button @click="collapseExpand" type="button"
            class="absolute top-3 left-3 opacity-60 hover:opacity-100 hover:scale-[1.02] active:scale-[0.98] duration-300">
            <img class="w-10 h-10" src="/expand.svg" alt="collapse/expand" />
        </button>
    </div>
</template>