<script setup lang="ts">
import { ref } from 'vue'
import EditContainer from './EditUtils/EditContainer.vue';
import EditInput from './EditUtils/EditInput.vue';
import EditTextArea from './EditUtils/EditTextArea.vue';

const { modelValue } = defineProps({
    modelValue: {
        type: Object as () => { src: string, alt: string, caption: string, body: string },
        required: true
    }
})

const emit = defineEmits(['update:modelValue'])

const src = ref(modelValue.src);
const alt = ref(modelValue.alt);
const caption = ref(modelValue.caption);
const body = ref(modelValue.body);

const updateSrc = (e: any) => {
    emit('update:modelValue', { src: e, alt: alt.value, caption: caption.value, body: body.value })
}

const updateAlt = (e: any) => {
    emit('update:modelValue', { src: src.value, alt: e, caption: caption.value, body: body.value })
}

const updateCaption = (e: any) => {
    emit('update:modelValue', { src: src.value, alt: alt.value, caption: e, body: body.value })
}

const updateBody = (e: any) => {
    emit('update:modelValue', { src: src.value, alt: alt.value, caption: caption.value, body: e })
}

</script>

<template>
    <EditContainer label="Text and Image" type="Text and Image">
        <div class="w-full flex justify-between">
            <EditInput v-on:update:modelValue="updateSrc" label="Image URL" v-model="src" />
            <EditInput v-on:update:modelValue="updateAlt" label="Image Alt Text" v-model="alt" />
        </div>
        <EditInput v-on:update:modelValue="updateCaption" label="Image Caption (optional)" v-model="caption" />
        <EditTextArea v-on:update:modelValue="updateBody" label="Body" v-model="body" />
    </EditContainer>
</template>