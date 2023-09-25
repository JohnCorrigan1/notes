<script setup lang="ts">
import { ref } from 'vue'
import EditContainer from './EditUtils/EditContainer.vue';
import EditInput from './EditUtils/EditInput.vue';
const { modelValue } = defineProps({
    modelValue: {
        type: Object as () => { src: string, alt: string, caption: string },
        required: true
    }
})
const src = ref(modelValue.src);
const alt = ref(modelValue.alt);
const caption = ref(modelValue.caption);

const emit = defineEmits(['update:modelValue'])

const updateSrc = (e: any) => {
    emit('update:modelValue', { src: e, alt: alt.value, caption: caption.value })
}

const updateAlt = (e: any) => {
    emit('update:modelValue', { src: src.value, alt: e, caption: caption.value })
}

const updateCaption = (e: any) => {
    emit('update:modelValue', { src: src.value, alt: alt.value, caption: e })
}

</script>

<template>
    <EditContainer label="Image" type="Image">
        <div class="w-full flex justify-between">
            <EditInput v-on:update:modelValue="updateSrc" label="Image URL" v-model="src" />
            <EditInput label="Image Alt Text" v-on:update:modelValue="updateAlt" v-model="alt" />
        </div>
        <EditInput label="Image Caption (optional)" v-on:update:modelValue="updateCaption" v-model="caption" />
    </EditContainer>
</template>
