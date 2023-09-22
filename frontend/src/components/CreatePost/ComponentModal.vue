<script setup lang="ts">
import { ref, defineEmits } from 'vue';
import ComponentPreview from './ComponentPreview.vue';
import { components } from '@/assets/components';

const { modal } = defineProps({
    modal: Number
});

const emit = defineEmits(['close']);

const closeModal = () => {
    emit('close');
};

const chooseComponent = (component: string) => {
    console.log(component);
};

</script>

<template>
    <div v-if="modal" @click="closeModal" class="bg-zinc-900 bg-opacity-60 z-0 absolute top-0 right-0 w-screen h-screen">
    </div>
    <div v-if="modal"
        class="overflow-y-scroll z-[50] rounded-lg w-2/3 h-2/3 max-w-2/3 max-h-2/3 absolute top-[16.67%] right-[16.67%] bg-zinc-200 p-5">
        <div class="grid componentPreviews gap-5">
            <ComponentPreview @click="chooseComponent" v-for="component in components" :componentPreview="component" />
        </div>
    </div>
</template>

<style scoped>
.componentPreviews {
    grid-template-columns: repeat(3, 1fr);
    /* grid-template-rows: repeat(250px) */
}
</style>