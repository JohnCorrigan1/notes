<script setup lang="ts">
import { ref } from 'vue'
import EditInput from './EditUtils/EditInput.vue'
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
    console.log(sectionHeader.value);
}

const sectionHeader = ref("");

</script>

<template>
    <div ref="open" class="w-full border-2 relative flex flex-col">
        <div class="flex p-5 justify-center items-center w-full">
            <h1 class="text-3xl font-bold">Post Section</h1>
        </div>
        <form class="flex flex-col w-full gap-5 p-5">
            <EditInput v-model="sectionHeader" />
            <div class="w-full">
                <label for="sectionBody" class="text-white font-semibold text-xl">Section Body</label>
                <textarea name="sectionBody" class="w-full rounded-md p-5 min-h-[250px]"
                    placeholder="This is a great section body" />
            </div>
        </form>
        <button @click="collapseExpand" type="button"
            class="absolute top-3 left-3 opacity-60 hover:opacity-100 hover:scale-[1.02] active:scale-[0.98] duration-300">
            <img src="/copyIcon.svg" alt="collapse/expand" />
        </button>
    </div>
    <div ref="closed" class="w-full border-2 relative hidden justify-center items-center p-5 ">
        <p>Post Section: Great section header</p>
        <button @click="collapseExpand" type="button"
            class="absolute top-3 left-3 opacity-60 hover:opacity-100 hover:scale-[1.02] active:scale-[0.98] duration-300">
            <img src="/copyIcon.svg" alt="collapse/expand" />
        </button>
    </div>
</template>